def gcd(a, b):
    if a == 0 or b ==0:
        return a + b
    if a < b:
        a,b = b,a
    return gcd(a % b, b)

n,m = map(int, input().split())
GCD = gcd(n, m)
print(n // GCD, m // GCD)
