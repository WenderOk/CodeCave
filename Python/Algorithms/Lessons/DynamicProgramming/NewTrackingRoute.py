N, M = map(int, input().split())
# N, M = 4, 3
H = [int(n) for n in input().split()]
P = [0] * (N+1)

for i in range(1, N):
    P[i+1] = P[i] + (H[i-1] < H[i])

for _ in range(M):
    l, r = map(int, input().split())
    print(P[r+1] - P[l])