from random import randint

k, n = map(int, input().split())
A = [int(x) for x in input().split()]

for i in range(k+1):
    nMax = i
    for j in range(i+1, k):
        if A[j]> A[nMax]:
            nMax = j
    if i != nMax:
        A[i], A[nMax] = A[nMax], A[i]

print(*A)
print(A[k])
