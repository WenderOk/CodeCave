from random import randint

A = [randint(0, 100) for _ in range(10)]
N = 10

for i in range(N//2-1):
    nMin = i
    for j in range(i+1, N//2):
        if A[j] < A[nMin]:
            nMin = j
    if i != nMin:
        A[i], A[nMin] = A[nMin], A[i]

    i = i+N//2
    nMax = i
    for j in range(i+1, N):
        if A[j] > A[nMax]:
            nMax = j
    if i != nMax:
        A[i], A[nMax] = A[nMax], A[i]

print(*A)

