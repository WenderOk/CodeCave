N = int(input())
k = 0
while N % 2 == 0:
    k += 1
    N //= 2
print(k)