x1, y1 = map(int, input().split())
x2, y2 = map(int, input().split())
x = abs(x1 - x2)
y = abs(y1 - y2)
while y != 0:
    x, y = y, x % y
print(x, y)