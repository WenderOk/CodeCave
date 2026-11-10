with open(r"C:\Users\TOP\source\repos\WenderRPO\CodeCave\Python\Algorithms\Lessons\Sorting\26-k4.txt", 'r') as F:
    n, k = map(int, F.readline().split())
    points = [int(line) for line in F]

for i in range(n-k*2):
    nMax = i
    for j in range(i+1, n):
        if points[j] > points[nMax]:
            nMax = j

    if i != nMax:
        points[i], points[nMax] = points[nMax], points[i]

i=s=0
for _ in range(k):
    s+=points[i]
    i+=1

avgPerf = int(s / k)
s=0
for _ in range(k):
    s+=points[i]
    i+=1
avgGood = int(s / k)

print(avgGood, avgPerf)