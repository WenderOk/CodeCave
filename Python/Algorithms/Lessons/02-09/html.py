a, b = int(input()), int(input()) 
mxsm = 0
mx = 0
for n in range(a, b + 1):
    sm = 1 + n
    d = 2
    while d * d <= n:
        if n % d == 0:
            sm += d
            if n // d != d:
                sm += n // d
        d += 1
        if sm >= mxsm:
            mx = n
            mxsm = sm
print(mx, mxsm)