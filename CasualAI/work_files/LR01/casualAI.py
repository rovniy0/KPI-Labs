import numpy as np
import pandas as pd
from dowhy import CausalModel

np.random.seed(42)
N = 1000

# Confounder Z
Z = np.random.normal(0, 1, N)

# Variable M (вплив на X)
M = np.random.normal(0, 1, N)

# Treatment X залежить від Z і M
X = 0.5 * Z + 0.8 * M + np.random.normal(0, 1, N)

# Outcome Y залежить від X і Z
Y = 1.2 * X + 0.7 * Z + np.random.normal(0, 1, N)

data = pd.DataFrame({"Z": Z, "M": M, "X": X, "Y": Y})
print(data.head())

causal_graph = """
digraph {
    Z -> X;
    Z -> Y;
    M -> X;
    X -> Y;
}
"""

model = CausalModel(
    data=data,
    treatment="X",
    outcome="Y",
    graph=causal_graph
)

model.view_model()

identified_estimand = model.identify_effect()
estimate = model.estimate_effect(
    identified_estimand,
    method_name="backdoor.linear_regression"
)
print(f"ATE (DoWhy): {estimate.value:.3f}")




