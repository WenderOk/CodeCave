N,c = int(input("Введите количество чисел: ")),0
for _ in range(N):
    a = int(input())
    if abs(a) in range(9, 100): c += a
if c==0: print("Ответ: нет")
else: print(f"Ответ: {c}")