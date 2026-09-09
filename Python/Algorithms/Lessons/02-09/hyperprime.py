def isPrime(n):
    if n % 2 == 0:
        return n == 2
    d = 3
    while d*d <= n and n % d != 0:
        d+=2
    return d*d > n

def isHyperPrime(n):
    for k in range(1, len(str(n))):
        x = n % (10 * k)
        if isPrime(x) and isPrime(n//(10*k)):
            print("YES")
            break
    else:
        print("NO")
x = int(input())
isHyperPrime(x)