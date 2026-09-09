for n in range(854321, 1087654+1):
    D = []
    d = 2
    step = 1
    if n % d != 0:
        step = 2
        d+=1
    while d*d <= n:
        if n % d == 0:
            if len(D) > 0 and d - D[len(D)-2] != 10:
                break
            D.append(d)
            if n // d != d:
                if len(D) > 3 and d - D[len(D)-2] != 10:
                    break
                D.append(n // d)
        d+=step
    else:
        if len(D) <= 1:
            continue
        D = sorted(D)
        for i in range (1, len(D)):
            if D[i] - D[i-1] != 10:
                break
        else:
            print(n, D[0])
