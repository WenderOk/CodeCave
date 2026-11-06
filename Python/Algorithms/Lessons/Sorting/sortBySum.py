from random import randint

def sumd(x):
    return x // 10 + x % 10

A = [randint(0, 99) for _ in range(10)]
N = 10

for i in range(N-1):
    nMin = i
    for j in range(i+1, N):
        if sumd(A[j]) < sumd(A[nMin]):
            nMin = j
    if i != nMin:
        A[i], A[nMin] = A[nMin], A[i]

print(*A)

