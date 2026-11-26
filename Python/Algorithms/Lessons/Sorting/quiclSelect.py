import random

n, k = map(int, input().split())
cans = [int(x) for x in input().split()]

def qSelect(A, k):
    if len(A) <= 1: return A[0]
    x = random.choice(A)
    right = [b for b in A if b < x]
    middle = [b for b in A if b == x]
    left = [b for b in A if b > x]
    if k < len(left):
        return qSelect(left, k)
    if k < len(left) + len(middle):
        return x
    k -= len(left)+len(middle)
    return qSelect(right, k)

print(qSelect(cans, k))