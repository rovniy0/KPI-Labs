import networkx as nx
import matplotlib.pyplot as plt
import matplotlib
from pgmpy.estimators import GES

from DAG_alg import G
from generate import data_lin, data_cat, data_mixed
from metrics import compare_graphs

matplotlib.use("TkAgg")


def GES_visualize(data, data_name):
    ges = GES(data)
    model = ges.estimate(scoring_method="bds")

    print("Кількість вузлів:", len(model.nodes()))
    print("Кількість ребер:", len(model.edges()))
    print("Структура DAG:", model.edges())

    nx_graph = nx.DiGraph()
    nx_graph.add_edges_from(model.edges())

    plt.figure(figsize=(8, 6))
    pos = nx.spring_layout(nx_graph, seed=42)
    nx.draw(
        nx_graph, pos,
        with_labels=True,
        node_size=3000,
        node_color="lightgreen",
        font_size=12,
        font_weight="bold",
        arrows=True,
        arrowsize=20
    )
    plt.title(f"GES результат — {data_name}")
    plt.show()

    # Порівняння з істинним DAG
    results = compare_graphs(G, nx_graph)
    print("Метрики:", results)


if __name__ == "__main__":
    datasets = {
        "Лінійні дані": data_lin,
        "Категоріальні дані": data_cat,
        "Змішані дані": data_mixed
    }
    for name, df in datasets.items():
        GES_visualize(df, name)
