N = int(input())
is_prime = [True] * (N+1)
for d in range(2, N+1):
    if is_prime[d]:
        for i in range(d*d, N+1, d):
            is_prime[i] = False
for i in range(2, N+1):
    if is_prime[i]:
        print(i, end=" ")