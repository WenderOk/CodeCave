for n in range(2, 1000):
    for d in range(2, n):
        if n % d == 0:
            break
    else: print(n)