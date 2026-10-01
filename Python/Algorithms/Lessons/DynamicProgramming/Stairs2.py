N = int(input())
A = [0] + [int(a) for a in input().split()]
for i in range(2, N+1):
    A[i] = A[i] + max(A[i-1], A[i-2]) + A[i]
print(A[N])