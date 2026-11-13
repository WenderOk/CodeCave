with open(r"/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Sorting/26-k2.txt", 'r') as F:
    n, k = map(int, F.readline().split())
    temps = [int(line) for line in F]

l = 0
r = n - 1

while l < r and l < k:
    swapped = False
    
    for i in range(l, r):
        if temps[i] > temps[i + 1]:
            temps[i], temps[i + 1] = temps[i + 1], temps[i]
            swapped = True
    r -= 1

    if not swapped: break

    for i in range(r, l, -1):
        if temps[i] < temps[i - 1]:
            temps[i], temps[i - 1] = temps[i - 1], temps[i]
            swapped = True
    l += 1

    if not swapped: break

mxRes = temps[n - k - 1]
avgSum = sum(temps[k:n - k]) / (n - 2 * k)

print(mxRes, int(avgSum))
