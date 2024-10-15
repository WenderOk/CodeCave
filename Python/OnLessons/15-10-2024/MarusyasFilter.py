N,cp,cn = int(input("Введите количество чисел: ")),0,0
for _ in range(N):
    a = int(input())
    if a>0: cp+=1
    elif a<0: cn+=1
print(f"Положительных: {cp}")
print(f"Отрицательных: {cn}")