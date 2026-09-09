def isPrime(n):
    if n % 2 == 0:
        return n == 2
    d = 3
    while d*d <= n and n % d != 0:
        d+=2
    return d*d > n

x = int(input())
d = 2
while d * d <=x:
    if x%d == 0 and isPrime(d):
        print(d, end=" ")
        if x // d != d and isPrime(x // d):
            print(x // d, end=" ")
    d+=1
