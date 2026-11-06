from random import randint

A = [randint(1, 100) for _ in range(10)]
N = 10

for i in range(N-1):
    nMax = i
    for j in range(i+1, N):
        if A[j] % 10 > A[nMax] % 10:
            nMax = j
    if i != nMax:
        A[i], A[nMax] = A[nMax], A[i]

print(*A)

