N = int(input())
K = [1]*N

for i in range(2, N):
    K[i] = K[i-1] + K[i-2]
print(K[N])