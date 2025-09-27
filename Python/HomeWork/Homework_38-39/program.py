import pandas as pd 
from sklearn.model_selection import train_test_split 
from sklearn.linear_model import LinearRegression 
from sklearn.metrics import mean_squared_error, r2_score 
import matplotlib.pyplot as plt 
 
url = "https://raw.githubusercontent.com/selva86/datasets/master/BostonHousing.csv" 
data = pd.read_csv(url) 
 
print(data.head()) 
 
X = data.drop(columns = ["medv"]) 
y = data["medv"] 
 
X_train, X_test, y_train, y_test = train_test_split( 
    X, y, test_size = 0.2, random_state = 42) 
 
model = LinearRegression() 
 
model.fit(X_train, y_train) 
 
y_pred = model.predict(X_test)

mse = mean_squared_error(y_test, y_pred) 
r2 = r2_score(y_test, y_pred) 
print(f"Среднеквадратичная ошибка (MSE): {mse}") 
print(f"Коэффициент детерминации (R^2): {r2}") 

plt.scatter(y_test, y_pred) 
plt.xlabel("Реальные значения") 
plt.ylabel("Предсказанные значения") 
plt.title("Реальные vs Предсказанные значения") 
plt.show()