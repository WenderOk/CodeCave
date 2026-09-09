a = 10002000
b = 10200000
for n in range(a, b+1):
    k = d = 2
    while d * d <= n:
        if n % n == 0:
            k+=1
            if n // d != d:
                k+=1
        d+=1
    if k >= 350:
        sm = 0
        old_n = n
        while n != 0:
            sm += n % 10
            n //= 10
        print(old_n, sm)
