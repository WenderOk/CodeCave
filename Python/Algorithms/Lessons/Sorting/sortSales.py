with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Sorting/26-k1.txt", 'r') as F:
    n, k = map(int, F.readline().split())
    prices = [int(line) for line in F]

prices.sort(reverse=True)

maxpr = prices[k]

totdis = 0
for i in range(k):
    totdis += prices[i] * 0.2

print(maxpr, int(totdis))


