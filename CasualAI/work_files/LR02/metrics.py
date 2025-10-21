
import networkx as nx
from sklearn.metrics import precision_score, recall_score, f1_score


def compare_graphs(true_graph: nx.DiGraph, est_graph: nx.DiGraph):
    nodes = list(true_graph.nodes())
    all_edges = [(u, v) for u in nodes for v in nodes if u != v]
    y_true = [1 if edge in true_graph.edges() else 0 for edge in all_edges]
    y_pred = [1 if edge in est_graph.edges() else 0 for edge in all_edges]

    precision = precision_score(y_true, y_pred, zero_division=0)
    recall = recall_score(y_true, y_pred, zero_division=0)
    f1 = f1_score(y_true, y_pred, zero_division=0)
    shd = sum(yt != yp for yt, yp in zip(y_true, y_pred))

    # Колайдери (X -> Z <- Y, без ребра X-Y)
    def find_colliders(g):
        colliders = set()
        for z in g.nodes():
            parents = list(g.predecessors(z))
            for i in range(len(parents)):
                for j in range(i + 1, len(parents)):
                    x, y = parents[i], parents[j]
                    if not g.has_edge(x, y) and not g.has_edge(y, x):
                        colliders.add((tuple(sorted([x, y])) + (z,)))
        return colliders

    true_colliders = find_colliders(true_graph)
    est_colliders = find_colliders(est_graph)

    correct_colliders = len(true_colliders & est_colliders)

    return {
        "Structural Hamming Distance": shd, # порівння з матрицею суміжності
        "Precision": precision, # точність. частка істинно позитивних прогнозів від заг. к-сті
        "Recall": recall, # Правильна ідентифікація позитивних випадків
        "F1": f1, # оцінка ефективності моделі класифікації
        "Correct Colliders": correct_colliders # спільний наслідок змінних
    }

