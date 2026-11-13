with open(r"C:\Users\TOP\source\repos\WenderRPO\CodeCave\Python\Algorithms\Lessons\Sorting\26-k2.txt", 'r') as F:
    n, k = map(int, F.readline().split())
    temps = [int(line) for line in F]


for i in range(n-k+1):
    nMin = i
    for j in range(i+1, n):
        if temps[j] < temps[nMin]:
            nMin = j

    if i != nMin:
        temps[i], temps[nMin] = temps[nMin], temps[i]

mxRes = temps[n-k-1]
avgSum = sum(temps[k:n-k]) / (n-2*k)

print(int(avgSum), mxRes)