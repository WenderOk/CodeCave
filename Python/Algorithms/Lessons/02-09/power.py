def pw(a, n):
    if n == 0:
        return 1
    else:
        return pw(a, n-1) * a