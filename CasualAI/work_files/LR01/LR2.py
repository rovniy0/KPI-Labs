# файл: causal_discovery_experiment.py
# pip install causallearn networkx numpy pandas scikit-learn matplotlib

import numpy as np
import pandas as pd
import networkx as nx
import matplotlib.pyplot as plt
from itertools import combinations
from causallearn.search.ConstraintBased.PC import pc
from causallearn.search.ConstraintBased.FCI import fci
from causallearn.search.ScoreBased.GES import ges
from causallearn.utils.cit import fisherz  # Gaussian CI test

# -------------------------
# 1) Еталонний DAG (варіант 16)
# -------------------------
# Вузли: ["Z", "M", "X", "Y"]
true_nodes = ["Z", "M", "X", "Y"]
true_edges = [("X", "Y"), ("Z", "X"), ("Z", "Y"), ("M", "X")]  # спрямовані ребра


def make_true_dag(nodes=true_nodes, edges=true_edges):
    G = nx.DiGraph()
    G.add_nodes_from(nodes)
    G.add_edges_from(edges)
    return G


G_true = make_true_dag()

# -------------------------
# 2) Генерація даних
# -------------------------
np.random.seed(42)
N = 5000


def gen_linear(N=1000, seed=42):
    np.random.seed(seed)
    Z = np.random.normal(0, 1, N)
    M = np.random.normal(0, 1, N)
    X = 0.5 * Z + 0.8 * M + np.random.normal(0, 1, N)
    Y = 1.2 * X + 0.7 * Z + np.random.normal(0, 1, N)
    return pd.DataFrame({"Z": Z, "M": M, "X": X, "Y": Y})


def gen_nonlinear(N=1000, seed=42):
    np.random.seed(seed)
    Z = np.random.normal(0, 1, N)
    M = np.random.normal(0, 1, N)
    # приклади нелінійних залежностей:
    X = 0.5 * np.sin(Z) + 0.8 * (M ** 2) + np.random.normal(0, 1, N)
    # Y залежить нелінійно від X і Z:
    Y = 1.0 * np.exp(0.5 * X) + 0.7 * np.tanh(Z) + np.random.normal(0, 1, N)
    return pd.DataFrame({"Z": Z, "M": M, "X": X, "Y": Y})


def gen_categorical(N=1000, seed=42):
    np.random.seed(seed)
    # Згенеруємо бінарні Z, M як функцію від нормалей
    Zc = (np.random.normal(0, 1, N) > 0).astype(int)  # бінарний
    Mc = np.random.choice([0, 1, 2], size=N, p=[0.5, 0.3, 0.2])  # три класи
    # X як категоріальний або бінарний функціонал від Zc і Mc (через логіт)
    logits = -0.2 + 0.8 * Zc + 0.5 * (Mc == 2).astype(int)
    prob = 1 / (1 + np.exp(-logits))
    Xc = (np.random.rand(N) < prob).astype(int)
    # Y бінарний з впливом X і Z:
    logits_y = -0.1 + 1.0 * Xc + 0.6 * Zc
    prob_y = 1 / (1 + np.exp(-logits_y))
    Yc = (np.random.rand(N) < prob_y).astype(int)
    return pd.DataFrame({"Z": Zc, "M": Mc, "X": Xc, "Y": Yc})


def gen_mixed(N=1000, seed=42):
    np.random.seed(seed)
    Z = np.random.normal(0, 1, N)
    Mc = np.random.choice([0, 1], size=N, p=[0.6, 0.4])  # категоріальний
    X = 0.5 * Z + 0.8 * Mc + np.random.normal(0, 1, N)  # числова X
    Y = 1.2 * X + 0.7 * Z + np.random.normal(0, 1, N)
    return pd.DataFrame({"Z": Z, "M": Mc, "X": X, "Y": Y})


# -------------------------
# 3) Утиліти: перетворення графів, метрики
# -------------------------
def nx_to_adj_matrix_directed(G, nodes_order):
    """Повертає матрицю 0/1 для спрямованих ребер a->b"""
    n = len(nodes_order)
    idx = {nname: i for i, nname in enumerate(nodes_order)}
    A = np.zeros((n, n), dtype=int)
    for u, v in G.edges():
        A[idx[u], idx[v]] = 1
    return A


def shd(adj_true, adj_pred):
    """
    Structural Hamming Distance для спрямованих графів:
    кількість змін досяжних для переведення adj_pred в adj_true
    (додавання/видалення/зміна напрямку ребра).
    adj_true, adj_pred — бінарні матриці однакового розміру.
    """
    n = adj_true.shape[0]
    dist = 0
    for i in range(n):
        for j in range(n):
            if i == j: continue
            a = adj_true[i, j]
            b = adj_pred[i, j]
            # якщо різниця в наявності ребра у вказаному напрямку — врахувати
            if a != b:
                dist += 1
    # Проте SHD зазвичай рахується як кількість відмінностей з поправкою на симетрію:
    # якщо adj_true[i,j]=1 і adj_true[j,i]=0, а adj_pred має протилежно,
    # це два відмінні елементи (видалити + додати з іншого боку).
    return dist


def undirected_edge_set_from_adj(adj):
    n = adj.shape[0]
    edges = set()
    for i in range(n):
        for j in range(i + 1, n):
            if adj[i, j] or adj[j, i]:
                edges.add((i, j))
    return edges


def precision_recall_f1_edges(adj_true, adj_pred):
    # розглядаємо ненапряму (структуру без орієнтації) для precision/recall
    true_set = undirected_edge_set_from_adj(adj_true)
    pred_set = undirected_edge_set_from_adj(adj_pred)
    tp = len(true_set & pred_set)
    fp = len(pred_set - true_set)
    fn = len(true_set - pred_set)
    prec = tp / (tp + fp) if (tp + fp) > 0 else 0.0
    rec = tp / (tp + fn) if (tp + fn) > 0 else 0.0
    f1 = 2 * prec * rec / (prec + rec) if (prec + rec) > 0 else 0.0
    return {"precision": prec, "recall": rec, "f1": f1, "tp": tp, "fp": fp, "fn": fn}


def v_structures_from_adj(adj, nodes_order):
    """
    Знайти всі v-structures (колайдери) a->c<-b, де a і b не з'єднані між собою.
    Повертаємо множину кортежів (a,c,b) як індекси.
    """
    n = adj.shape[0]
    vstr = set()
    for a in range(n):
        for b in range(n):
            if a == b: continue
            for c in range(n):
                if c == a or c == b: continue
                if adj[a, c] == 1 and adj[b, c] == 1 and adj[a, b] == 0 and adj[b, a] == 0:
                    # a->c and b->c and no edge between a and b
                    # Уникаємо подвійного рахунку: сортую a,b у кортежі
                    vstr.add((min(a, b), c, max(a, b)))
    return vstr


# -------------------------
# 4) Wrapper: запустити PC/FCI/GES на наборі даних
# -------------------------
# Вставити замість попередньої реалізації run_discovery_algorithms та допоміжних частин

def extract_edges_from_causallearn_result(result, nodes_order):
    """
    Універсальна функція: пробує витягти спрямовані ребра з результатів pc/fci/ges
    Працює з кількома можливими форматами, які повертає causallearn.
    Повертає список кортежів (u_name, v_name) для спрямованих ребер u->v.
    """
    edges = []

    # Якщо результат — numpy adjacency mat (n x n)
    try:
        import numpy as _np
        if isinstance(result, _np.ndarray):
            n = result.shape[0]
            for i in range(n):
                for j in range(n):
                    if result[i, j] != 0:
                        edges.append((nodes_order[i], nodes_order[j]))
            return edges
    except Exception:
        pass

    # Якщо результат — сам граф об'єкт з атрибутом G або .G
    graph_obj = None
    if hasattr(result, "G"):
        graph_obj = result.G
    elif hasattr(result, "graph"):
        graph_obj = result.graph
    elif isinstance(result, tuple) and len(result) > 0:
        # інколи повертається tuple (graph, other), або (skeleton, graph)
        # пробуємо знайти елемент, що має метод get_edges або attribute 'get_all_edges'
        for item in result:
            if item is None:
                continue
            if hasattr(item, "get_edges") or hasattr(item, "edges") or hasattr(item, "getAllEdges"):
                graph_obj = item
                break

    # Якщо знайшли graph_obj — пробуємо витягти ребра
    if graph_obj is not None:
        # Варіанти: graph_obj.get_edges(), graph_obj.edges, graph_obj.getAllEdges()
        if hasattr(graph_obj, "get_edges"):
            try:
                for e in graph_obj.get_edges():
                    # У різних версіях елемент ребра має різні поля
                    # Тож намагаємось кількома способами
                    try:
                        u = e.tail.name
                        v = e.head.name
                        edges.append((u, v))
                    except Exception:
                        try:
                            u = e.get_tail_name()
                            v = e.get_head_name()
                            edges.append((u, v))
                        except Exception:
                            # спробуємо str-розбор
                            s = str(e)
                            # приклад 'X1 --> X2' або 'X1 o-> X2'
                            parts = s.replace('-', ' ').replace('>', ' ').replace('<', ' ').split()
                            if len(parts) >= 2:
                                edges.append((parts[0], parts[-1]))
            except Exception:
                pass
        elif hasattr(graph_obj, "edges"):
            try:
                # networkx-like
                for (u, v) in graph_obj.edges:
                    edges.append((u, v))
            except Exception:
                pass
    else:
        # Останній варіант — якщо result містить текстний вивід з 'X3 --> X4' (як у твоєму логі)
        try:
            s = str(result)
            # шукаємо паттерн 'X<number> --> X<number>'
            import re
            for m in re.finditer(r"([A-Za-z0-9_]+)\s*[-o]*[<\-]+>[-o]*\s*([A-Za-z0-9_]+)", s):
                u = m.group(1)
                v = m.group(2)
                # якщо в nodes_order є такі назви — додаємо
                if u in nodes_order and v in nodes_order:
                    edges.append((u, v))
        except Exception:
            pass

    # Нормалізуємо: повертаємо унікальні ребра
    edges = list(dict.fromkeys(edges))
    return edges


def run_discovery_algorithms(df, nodes_order, data_type="continuous"):
    X = df[nodes_order].values
    results = {}
    alpha = 0.05

    # PC (Constraint-based)
    try:
        print("Running PC...")
        # різні версії pc мають різні підписи — спробуємо кілька
        try:
            pc_output = pc(X, alpha=alpha, indep_test=fisherz, labels=nodes_order)
        except TypeError:
            # інша версія: pc(X, labels=nodes_order, alpha=alpha, indep_test=fisherz)
            pc_output = pc(X, labels=nodes_order, alpha=alpha, indep_test=fisherz)
        edges_pc = extract_edges_from_causallearn_result(pc_output, nodes_order)
        Gpc = nx.DiGraph()
        Gpc.add_nodes_from(nodes_order)
        for u,v in edges_pc:
            Gpc.add_edge(u, v)
        results['PC'] = nx_to_adj_matrix_directed(Gpc, nodes_order)
    except Exception as ex:
        print("PC error:", ex)
        results['PC'] = None

    # FCI
    try:
        print("Running FCI...")
        try:
            fci_output = fci(X, alpha=alpha, indep_test=fisherz, labels=nodes_order)
        except TypeError:
            fci_output = fci(X, labels=nodes_order, alpha=alpha, indep_test=fisherz)
        edges_fci = extract_edges_from_causallearn_result(fci_output, nodes_order)
        Gfci = nx.DiGraph()
        Gfci.add_nodes_from(nodes_order)
        for u,v in edges_fci:
            Gfci.add_edge(u, v)
        results['FCI'] = nx_to_adj_matrix_directed(Gfci, nodes_order)
    except Exception as ex:
        print("FCI error:", ex)
        results['FCI'] = None

    # GES (score-based)
    try:
        print("Running GES...")
        # різні версії: ges(X, labels=...) або ges(X)
        try:
            ges_output = ges(X, labels=nodes_order)
        except TypeError:
            try:
                ges_output = ges(X)
            except TypeError:
                # інша підпис — передаємо матрицю та отримаємо tuple
                ges_output = ges(X)
        edges_ges = extract_edges_from_causallearn_result(ges_output, nodes_order)
        Gges = nx.DiGraph()
        Gges.add_nodes_from(nodes_order)
        for u,v in edges_ges:
            Gges.add_edge(u, v)
        results['GES'] = nx_to_adj_matrix_directed(Gges, nodes_order)
    except Exception as ex:
        print("GES error:", ex)
        results['GES'] = None

    return results



# -------------------------
# 5) Оцінка знайдених графів проти еталону
# -------------------------
def evaluate_predicted(adj_pred, adj_true, nodes_order):
    if adj_pred is None:
        return None
    res = {}
    res['shd'] = shd(adj_true, adj_pred)
    pr = precision_recall_f1_edges(adj_true, adj_pred)
    res.update(pr)
    # v-structures
    v_true = v_structures_from_adj(adj_true, nodes_order)
    v_pred = v_structures_from_adj(adj_pred, nodes_order)
    res['v_true_count'] = len(v_true)
    res['v_pred_count'] = len(v_pred)
    res['v_correct_oriented'] = len(v_true & v_pred)
    return res


# -------------------------
# 6) Запуск експериментів для кожного типу даних
# -------------------------
def run_experiment_all():
    datasets = {
        "linear": gen_linear(N),
        "nonlinear": gen_nonlinear(N),
        "categorical": gen_categorical(N),
        "mixed": gen_mixed(N),
    }

    nodes_order = ["Z", "M", "X", "Y"]
    adj_true = nx_to_adj_matrix_directed(G_true, nodes_order)

    all_results = {}

    for name, df in datasets.items():
        print("\n=== Dataset:", name, "===\n")
        print(df.head())
        # якщо категоріальні, можна кодувати як числа — вже зроблено у gen_categorical
        preds = run_discovery_algorithms(df, nodes_order,
                                         data_type=("categorical" if name == "categorical" else "continuous"))
        evals = {}
        for alg, adj in preds.items():
            print(f"Evaluating {alg} ...")
            res = evaluate_predicted(adj, adj_true, nodes_order)
            evals[alg] = res
            print(alg, res)
        all_results[name] = {"preds": preds, "evals": evals}
    return all_results


if __name__ == "__main__":
    results = run_experiment_all()
    # Можеш зберегти results у JSON / pickle та візуалізувати
    import json

    # серіалізація простих елементів:
    print("\nFinal summary:")
    for dname, info in results.items():
        print("Dataset:", dname)
        for alg, ev in info["evals"].items():
            print(" ", alg, "->", ev)
