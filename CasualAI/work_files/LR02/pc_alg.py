from pgmpy.estimators import PC
import matplotlib.pyplot as plt
import networkx as nx
import matplotlib

matplotlib.use("TkAgg")

from generate import data_lin, data_mixed, data_cat, data_nonlin
from DAG_alg import G
from metrics import compare_graphs


def PC_visualize(df, name):
    print(f"\n=== {name} ===")

    # Перетворюємо всі значення у float
    df = df.astype(float)

    # Ініціалізація PC-алгоритму
    pc = PC(df)
    model = pc.estimate(ci_test="pearsonr", alpha=0.05, n_jobs=-1)

    # Інформація про побудований граф
    print("Кількість вузлів:", len(model.nodes()))
    print("Кількість ребер:", len(model.edges()))
    print("Структура DAG:", list(model.edges()))

    if len(model.nodes()) == 0:
        print("⚠️ Порожній граф — перевір правильність даних.")
        return

    # Створюємо networkx-граф для візуалізації
    nx_graph = nx.DiGraph()
    nx_graph.add_edges_from(model.edges())

    # Візуалізація графа
    plt.figure(figsize=(8, 6))
    pos = nx.circular_layout(nx_graph)
    nx.draw(
        nx_graph,
        pos,
        with_labels=True,
        node_size=3000,
        node_color="skyblue",
        font_size=12,
        font_weight="bold",
        arrows=True,
        arrowsize=20
    )
    plt.title(f"PC-Algorithm Result — {name}")
    plt.show()

    # Порівняння з еталонним DAG
    results = compare_graphs(G, nx_graph)
    print("Метрики:", results)


if __name__ == "__main__":
    PC_visualize(data_lin, "Лінійні змінні")
    PC_visualize(data_mixed, "Змішані змінні")
    PC_visualize(data_cat, "Категоріальні дані")
    PC_visualize(data_nonlin, "Нелінійні дані")
