A = []
with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/ProcessingNumberSeqs/27v01_B.txt", "r") as F:
    N = int(F.readline())
    for _ in range(N):
        A.append(tuple(map(int, F.readline().split())))

diff = float('inf')
S = 0

for i in A:
    S += max(i[0], i[1])
    curDiff = max(i[0], i[1]) -  min(i[0], i[1])
    if curDiff < diff and curDiff % 3 != 0:
        diff = curDiff

if S % 3 == 0:
    S-=diff
print(S)


