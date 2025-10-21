import networkx as nx
import matplotlib.pyplot as plt
import matplotlib
matplotlib.use("TkAgg")

# X → Y, Z → X, Z → Y, M → X
G = nx.DiGraph()
G.add_edges_from([
    ("X", "Y"),
    ("Z", "X"),
    ("Z", "Y"),
    ("M", "X")
])


def show_dag(graph: nx.DiGraph):
    plt.figure(figsize=(6, 4))
    nx.draw(
        graph,
        with_labels=True,
        node_color="lightblue",
        node_size=3000,
        arrows=True,
        font_size=12,
        font_weight="bold"
    )
    plt.title("Еталонний причинно-наслідковий DAG (варіант 16)")
    plt.show()


if __name__ == "__main__":
    show_dag(G)
