a, b = map(int, input().split())
a, b, = abs(a), abs(b)
while b != 0:
    a, b = b, a % b
print(a+b)