with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Sorting/26.txt") as f:
    s, n = map(int, f.readline().split())
    files = sorted(int(line) for line in f)

curSum = c = 0

for size in files:
    if curSum + size <= s:
        curSum += size
        c += 1
    else:
        break

curSum -= files[c - 1]
mx = 0

for i in range(c - 1, n):
    if curSum + files[i] <= s:
        mx = files[i]
    else:
        break

print(c, mx)

