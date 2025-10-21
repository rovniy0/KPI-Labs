import networkx as nx
from causallearn.search.ConstraintBased.FCI import fci
import matplotlib.pyplot as plt
import matplotlib
import pandas as pd
import numpy as np

from DAG_alg import G
from generate import data_lin, data_nonlin, data_cat, data_mixed
from metrics import compare_graphs

matplotlib.use("TkAgg")


def FCI_visualize(g, var_names, title):
    nx_g = nx.DiGraph()
    node_map = {node: var_names[i] for i, node in enumerate(g.get_nodes())}
    nx_g.add_nodes_from(node_map.values())

    for edge in g.get_graph_edges():
        node1, node2 = node_map[edge.node1], node_map[edge.node2]
        nx_g.add_edge(node1, node2)

    plt.figure(figsize=(8, 6))
    pos = nx.spring_layout(nx_g, seed=42)
    nx.draw(
        nx_g,
        pos,
        with_labels=True,
        node_size=3000,
        node_color="skyblue",
        font_size=12,
        font_weight="bold",
        arrows=True,
        arrowsize=20
    )
    plt.title(title)
    plt.show()

    print("Кількість вузлів:", len(nx_g.nodes()))
    print("Кількість ребер:", len(nx_g.edges()))
    print("Структура DAG:", list(nx_g.edges()))

    results = compare_graphs(G, nx_g)
    print("Метрики:", results)
    print("=" * 60)


if __name__ == "__main__":
    datasets = [
        (data_lin, "Лінійні дані"),
        (data_nonlin, "Нелінійні дані"),
        (data_cat, "Категоріальні дані"),
        (data_mixed, "Змішані дані"),
    ]

    for dataset, title in datasets:
        print("=" * 60)
        print(f"Виконуємо FCI для: {title}")

        df = dataset.copy()
        df = df.apply(pd.to_numeric, errors='coerce')
        df = df.dropna()

        data_np = df.to_numpy(dtype=float)
        fci_result, _ = fci(data_np, independence_test_method="fisherz")

        FCI_visualize(fci_result, list(df.columns), title)
