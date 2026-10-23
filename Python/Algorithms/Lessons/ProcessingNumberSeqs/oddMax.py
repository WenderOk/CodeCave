with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/ProcessingNumberSeqs/271-A.txt", "r") as F:
    N = int(F.readline())
    A = [int(n) for n in F.readline().split()]
    R = A.pop()

maxEv, maxOd = -1, 0

for n in A:
    if n % 2 == 0: maxEv = max(n, maxEv)
    else: maxOd = max(n, maxOd)   

print("Контрольная сумма =", maxEv+maxOd)
if(maxEv == -1 or maxOd == 0):
    print("R=-1")
else:
    if(maxEv + maxOd == R): print("Контрольная сумма пройдена")
    else: print("Контрольная сумма не пройдена")


