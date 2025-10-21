# X → Y, Z → X, Z → Y, M → X; Confounder + вплив M на X

import networkx as nx
import matplotlib.pyplot as plt

G = nx.DiGraph()
edges = [("X", "Y"), ("Z", "X"), ("Z", "Y"), ("M", "X")]
G.add_edges_from(edges)

pos = nx.spring_layout(G, seed=42)
nx.draw(G, pos, with_labels=True, node_size=2000, node_color="lightblue", arrowsize=20, font_size=12)
plt.title("Причинна структура (Варіант 16)")
plt.show()
