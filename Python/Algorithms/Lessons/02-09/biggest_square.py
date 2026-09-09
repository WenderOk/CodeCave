def isPrime(n):
    if n % 2 == 0:
        return n == 2
    d = 3
    while d*d <= n and n % d != 0:
        d+=2
    return d*d > n

x = int(input())
print("YES" if isPrime(x) else "NO")