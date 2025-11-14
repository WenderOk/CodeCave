n, s, c = 0,0,0
while n >= 0:
    s += n
    c += 1
    n = int(input())
else: c -= 1
print(s // c)