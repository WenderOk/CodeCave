N = int(input())
D = [1, N]
d = 2
while d * d <= N:
    if N % d == 0:
        D.append(d)
        if N // d != d:
            D.append(N // d)
    d += 1
print (*sorted(D))