k = 0
for n in range(2, 20000+1):
    sm = 0
    d = 2
    step = 1
    if n % d != 0:
        step = 2
        d+=1
    while d*d <= n:
        if n % d == 0:
            sm += d
            if n // d != d:
                sm += n // d
        if sm > n: 
            break
        d+=step
    if n < sm:
        k+=1
print(k)