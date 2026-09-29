N = int(input())
A = [1]*N
B = [1]*(N-1)
A[2] = A[2-1] + A[2-2]
for i in range(3, N):
    A[i] = A[i-1] + A[i-2]
    A[i] += B[i-1]
    B[i] = B[i-1] + A[i-1]
    if i >= 4:
        B[i] += B[i-2]
print(A)
print(B)