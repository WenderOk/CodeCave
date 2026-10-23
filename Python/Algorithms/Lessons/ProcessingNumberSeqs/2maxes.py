A = [int(n) for n in input().split()]
R = A.pop()

max1, max2 = -1, -1

for i in A:
    if i > max1:
        max2 = max1
        max1 = i
    elif i > max2:
        max2 = i

print("Контрольная сумма =", max1 + max2)
if(max1 + max2 == R):
    print("Контрольная сумма пройдена")
else:
    print("Контрольная сумма не пройдена")
