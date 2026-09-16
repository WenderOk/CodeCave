N = int(input())
A = [int(a) for a in input().split()]
M = int(input())
B = [int(b) for b in input().split()]
R = [0] * len(B)

for b in range(len(B)):
    i = 0
    while i < len(A) and A[i] != B[b]:
        i += 1
    if i != len(A):
        R[b] = i + 1
    print(R)
