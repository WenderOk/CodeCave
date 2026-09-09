N = int(input())
mxk = 0
k = 0
while N % 2 == 0:
    k += 1
    N //= 2
mxk = k
p = 3
while p*p <= N:
    k = 0
    while N % p == 0:
        N //= p
        k += 1
    p += 2
    mxk = max(mxk, k)
if N > 1:
    mxk = max(mxk, 1)
print(mxk)