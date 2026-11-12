import random

def qSort(A):
    if len(A) <= 1: return A
    x = random.choice(A)
    B1 = [b for b in A if b < x]
    BX = [b for b in A if b == x]
    B2 = [b for b in A if b > x]
    return qSort(B1) + BX + qSort(B2)

n = 10
a = [random.randint(1, 10) for _ in range(n)]

print(a)
print(qSort(a[:n//2]) + qSort(a[n//2:]))
