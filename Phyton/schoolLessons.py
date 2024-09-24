les = int(input("Введите номер урока: "))
time = 8 * 60 + 30
time += les * 45 + 10 * (les - 1)
print("{}:{}".format(time // 60, time % 60))
