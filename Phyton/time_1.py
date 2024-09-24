sec = int(input("Введите количество секунд: "))
print("{} ч. {} мин. {} с.".format(sec // 3600, sec// 60 % 60, sec % 60))