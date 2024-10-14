from math import sqrt, pi
mod = input("Введите название типа фигуры: ")
if mod == "треугольник":
    a,b,c = int(input("Введите длину стороны A: ")), int(input("Введите длину стороны B: ")), int(input("Введите длину стороны C: "))
    p = (a+b+c)/2
    print(round(sqrt(p*(p-a)*(p-b)*(p-c)), 1))
elif mod == "круг":
    r = int(input("Введите радиус окружности: "))
    print(round(pi*r**2, 1))
elif mod == "прямоугольник":
    a,b = float(input("Введите длину стороны A: ")), float(input("Введите длину стороны B: "))
    print(a*b)
else: print("Введено некорректное название фигуры!")