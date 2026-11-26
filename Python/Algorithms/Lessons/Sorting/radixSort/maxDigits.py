with open(r"C:\Users\TOP\source\repos\WenderRPO\CodeCave\Python\Algorithms\Lessons\Sorting\radixSort\271-A.txt") as f:
    n = int(f.readline())
    num = [int(a) for a in f.readline().split()]

mxN = [0]*10
for n in num:
    while n > 0:
        mxN[n % 10] += 1
        n //= 10
mxi = 0
res = [mxN[0]]
for i in range(1, 10):
    if mxN[mxi] < mxN[i]:
        mxi = i
        res=[i]
    elif mxN[mxi] == mxN[i]:
        res.append(i)
print(res)
