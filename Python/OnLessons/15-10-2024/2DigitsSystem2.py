a = input("Введите число: ")
for d in a:
    if d not in "01": 
        print("Нет.")
        break
else: print("Да.")