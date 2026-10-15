n, k, m = map(int, input().split())
A = [int(n) for n in input().split()]
P = [0]*(len(A)+1)

for i in range(n):
    P[i+1] = P[i] + A[i]

for i in range(n-k-1):
    if P[i+k+1] - P[i] == m:
        print(i+1)
   