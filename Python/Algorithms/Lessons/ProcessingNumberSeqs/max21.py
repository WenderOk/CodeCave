with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/ProcessingNumberSeqs/272-B.txt", "r") as F:
    N = int(F.readline())
    A = [int(n) for n in F.readline().split()]
    R = A.pop()

max3 = max7 = max21 = mx = -1

for i in A:
    if i % 21 == 0 and i > max21:
        max21 = i
    else:
        if i > mx:
            mx = i
        if i > max3 and i % 3 == 0:
            max3 = i
        elif i > max7 and i % 7 == 0:
            max7 = i

totalmax = max(mx*max21, max3*max7)

print("Контрольная сумма =", totalmax)
if(totalmax == R):
    print("Контрольная сумма пройдена")
else:
    print("Контрольная сумма не пройдена")


