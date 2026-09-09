n = int(input())
R = 0
for m in range(1, n+1):
    a = 0
    while m % 2 == 0:
        a += 1
        m //= 2
    b = 0
    while m % 3 == 0:
        b += 1
        m //= 3
    if b>a:
        R+=1
print(R)