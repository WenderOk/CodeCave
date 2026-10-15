a = [int(n) for n in input().split()]
n = len(a)
p = [0] * (n+1)
for i in range(1, n+1):
    p[i] = p[i-1] + a[i-1]
ibest = jbest = imin = 0
for j in range(1, n):
    if p[j] < p[imin]:
        imin = j
    if p[j+1] - p[imin] > p[jbest+1] - p[ibest]:
        ibest, jbest = imin, j
print(ibest, jbest)
