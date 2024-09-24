sec = int(input("Введите количество секунд: "))
hours = sec // 3600
hours //= 12
print("{} ч. {} мин. {} с.".format(hours, sec // 60 % 60, sec % 60))