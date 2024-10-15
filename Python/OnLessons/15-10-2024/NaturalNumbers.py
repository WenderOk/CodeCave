mx,N = int(input()),-1
for _ in range(N):
    n = int(input())
    for d in range(2, n):
        if n % d == 0: break
    else: mx=n
if mx == -1: print("Ответ: нет")
else: print(f"Ответ: {mx}")