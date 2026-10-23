N = int(input())
maxp = maxe = maxo = -1
L = 9
queue = [int(input() for _ in range(L))]

for _ in range(N-L):
    a = queue.pop(0)
    if a % 2 == 0 and a > maxe:
        maxe = a
    elif a % 2 != 0 and a > maxo:
        maxo = a
    n = input()
    if n % 2 != 0 and maxe * n > maxp:
        maxp = n * maxe
    if n % 2 == 0 and maxo * n > maxp:
        maxp = max(maxp, max(maxe, maxo) * n)
    queue.append(n)
print(maxp)

