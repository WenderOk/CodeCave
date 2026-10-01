N, k = map(int, input().split())
R = [int(r) for r in input().split()]
D = [0]*(N+1)
P = [None] * (N+1)

D[1] = R[0]
for i in range(2, N+1):
    mn = float('inf')
    for j in range(max(i-k, 1), i):
        if mn > D[j]:
            P[i]=j
            mn=D[j]
    D[i] = mn + R[i-1]
print(D, P, sep="\n")