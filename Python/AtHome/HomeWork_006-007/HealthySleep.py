a,b,h = int(input("Введите минимальное количество часов сна: ")),int(input("Введите макимальное количество часов сна: ")),int(input("Введите текущее количество часов сна: "))
if a > b: print("Введено некоректное количесто часов для диапазона здорового сна!")
else:
    if a <= h <= b: print("Это нормально")
    elif h < a: print("Недосып")
    else: print("Пересып")