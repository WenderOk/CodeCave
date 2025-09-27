from math import factorial
n,m = int(input()), int(input())
print(factorial(n) / (factorial(m) * factorial(n-m)) * 2**(n-m))