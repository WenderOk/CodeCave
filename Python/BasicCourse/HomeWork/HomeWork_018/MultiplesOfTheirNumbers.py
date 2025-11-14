N = int(input("Введите N:\n"))
for i in range(1,N+1):
    a,d = i,True
    while a > 0:
        if a % 10 == 0 or i % (a % 10) != 0:
            d = False
            break
        a //= 10
    if d == True: print(i)
