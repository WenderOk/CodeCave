from math import sqrt
x1, y1 = map(float, input("Введите координаты точки А:\n").split())
x2, y2 = map(float, input("Введите координаты точки B:\n").split())
print("Длина отрезка АВ = {}".format(round(sqrt((x2-x1)**2 + (y2-y1)**2), 3)))