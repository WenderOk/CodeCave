n= int(input("Введите число от 1 до 9: "))
if not(1 <= n <= 9): print("Введено некорректное число!")
else:
    for i in range(10): print(f"{n} * {i+1} = {n*(i+1)}")