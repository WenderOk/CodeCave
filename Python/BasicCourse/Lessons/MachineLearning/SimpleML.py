from sklearn.linear_model import LinearRegression

X = [[2],[12],[3],[5]]
y = [2,3,6,2]
model = LinearRegression()
model.fit(X,y)

pred = model.predict([[13]])
print(pred)