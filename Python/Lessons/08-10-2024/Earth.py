from math import pi
n,h = int(input("Введите количество оборотов: ")), int(input("Введите высоту спутника: "))
r = 6373
c = round(((2*pi*(r+h))*n), 4)
print("C =", c, "km")