import numpy as np
import pandas as pd

# Генерація даних
np.random.seed(0)
n = 1000

# Z — confounder
Z_num = np.random.normal(0, 1, n)

# M впливає на X
M_num = np.random.normal(0, 1, n)

# X залежить від Z і M
X_num = 2 * Z_num + 1.5 * M_num + np.random.normal(0, 0.3, n)

# Y залежить від X і Z
Y_num = 3 * X_num + 2 * Z_num + np.random.normal(0, 0.3, n)

# === Лінійні числові дані ===
data_lin = pd.DataFrame({
    "Z": Z_num,
    "M": M_num,
    "X": X_num,
    "Y": Y_num
})

# Нелінійні дані
Z_nonlin = np.random.normal(0, 1, n)
M_nonlin = np.random.uniform(-1, 1, n)
X_nonlin = np.sin(Z_nonlin) + 0.5 * M_nonlin**2 + np.random.normal(0, 0.2, n)
Y_nonlin = np.exp(0.3 * X_nonlin) + np.cos(Z_nonlin) + np.random.normal(0, 0.2, n)

data_nonlin = pd.DataFrame({
    "Z": Z_nonlin,
    "M": M_nonlin,
    "X": X_nonlin,
    "Y": Y_nonlin
})

# Категоріальні дані
boolean_options = [True, False]
Z_cat = np.random.choice(boolean_options, n)
M_cat = np.random.choice(boolean_options, n)
X_cat = np.logical_xor(Z_cat, M_cat)  # X залежить від Z і M
Y_cat = np.logical_or(X_cat, Z_cat)   # Y залежить від X і Z

data_cat = pd.DataFrame({
    "Z": Z_cat,
    "M": M_cat,
    "X": X_cat,
    "Y": Y_cat
})

# Мішані дані
Z_mixed = np.random.normal(0, 1, n)
M_mixed = np.random.choice(boolean_options, n)
X_mixed = 2 * Z_mixed + M_mixed.astype(int) + np.random.normal(0, 0.5, n)
Y_mixed = 3 * X_mixed + 0.5 * Z_mixed + np.random.normal(0, 0.5, n)

data_mixed = pd.DataFrame({
    "Z": Z_mixed,
    "M": M_mixed,
    "X": X_mixed,
    "Y": Y_mixed
})

if __name__ == "__main__":
    print("Лінійні дані")
    print(data_lin.head(), "\n")

    print("Нелінійні дані")
    print(data_nonlin.head(), "\n")

    print("Категоріальні дані")
    print(data_cat.head(), "\n")

    print("Змішані дані")
    print(data_mixed.head())
