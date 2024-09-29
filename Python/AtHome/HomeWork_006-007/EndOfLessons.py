n = int(input("Введите нормер урока: "))
if not(0<=n<=10):
    print("Введено недействительное количество уроков!")
else:
    minuts = 540 + n * 45
    if n % 2 == 0: 
        minuts += (n // 2 * 5) + ((n // 2) -1) * 15
    else: minuts += n // 2 * 20
    print(minuts // 60, minuts % 60)