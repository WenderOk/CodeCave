N = int(input())
k = 0
N = N

while N % 2 == 0:
    k += 1
    N //= 2

p = 3
while p*p <= N:
    if N % p == 0:
        while N % p == 0:
            k += 1
            N //= p
        print(p, k)
    p += 2
if N > 1:
    print(N, 1)