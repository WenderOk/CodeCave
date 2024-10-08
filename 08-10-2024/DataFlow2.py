n, P, N = int(input()), 0, 0
while n != 0: 
    if n > 0: P+=1
    elif n < 0: N+=1
    n = int(input())
print(f"Положительные: {P}\n",f"Отрицательные: {N}", sep="")