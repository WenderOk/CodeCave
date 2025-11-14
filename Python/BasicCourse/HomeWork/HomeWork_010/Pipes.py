from math import pi
r, d, h = int(input("Введите внешний радиус трубы: ")), int(input("Введите толщину стенки трубы: ")), int(input("Введите длину трубы: "))
if r <= 0 or d <= 0 or h <= 0: print("Одно или несколько значений некорректны!")
else:
    exVol = pi*r**2*h
    inVol = pi*(r-d)**2*h
    print(round(exVol-inVol, 2))