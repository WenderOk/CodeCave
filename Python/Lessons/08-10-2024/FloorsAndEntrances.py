n, k, a = map(int, input().split())
a-=1
print(a // (n * k) + 1)
print(a % (n*k) // n + 1)