a,b = map(int, input("Введите стороны прямоугольника через пробел: ").split())
print("Можно отрезать {} квадратов.".format((a // 30) * (b // 30)))