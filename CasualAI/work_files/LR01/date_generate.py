import numpy as np
import pandas as pd

np.random.seed(42)
N = 1000

# Confounder Z хибна кореляція >0< (похибка)
Z = np.random.normal(0, 1, N)

# Variable M (на X)
M = np.random.normal(0, 1, N)

# Treatment X залежить від Z і M
X = 0.5 * Z + 0.8 * M + np.random.normal(0, 1, N)

# Outcome Y залежить від X і Z
Y = 1.2 * X + 0.7 * Z + np.random.normal(0, 1, N)

data = pd.DataFrame({"Z": Z, "M": M, "X": X, "Y": Y})
print(data.head())
