import numpy as np
import pandas as pd
from sklearn.linear_model import LinearRegression
from sklearn.ensemble import RandomForestRegressor

np.random.seed(42)
N = 1000

Z = np.random.normal(0, 1, N)
M = np.random.normal(0, 1, N)
X = 0.5 * Z + 0.8 * M + np.random.normal(0, 1, N)
Y = 1.2 * X + 0.7 * Z + np.random.normal(0, 1, N)

data = pd.DataFrame({"Z": Z, "M": M, "X": X, "Y": Y})

# ML-підхід: прогнозуємо Y за X
X_ml = data[["X"]]
y_ml = data["Y"]

# Лінійна регресія
linreg = LinearRegression().fit(X_ml, y_ml)
lin_coef = linreg.coef_[0]
print(f"Оцінка ефекту (Linear Regression): {lin_coef:.3f}")

# Random Forest
rf = RandomForestRegressor(n_estimators=100, random_state=42).fit(X_ml, y_ml)

# обчислимо середню зміну Y при X+1
x_plus1 = X_ml + 1
rf_pred_diff = rf.predict(x_plus1) - rf.predict(X_ml)
print(f"Оцінка ефекту (Random Forest, середнє): {rf_pred_diff.mean():.3f}")
