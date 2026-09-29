L, R = map(int, input().split())
is_prime = [True] * 4  + [False, True] * ((R-3) // 2)
d = 3
while d*d <= R:
    if is_prime[d]:
        for i in range(d*d, R+1, d*2):
            is_prime[i] = False
    d+=2
primes = [p for p in range(L, R+1) if is_prime[p]]
if len(primes):
    print(*primes)
else:
    print("empty")