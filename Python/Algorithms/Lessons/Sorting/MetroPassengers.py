with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Sorting/metro.txt") as f:
  n = int(f.readline())
  maxT = 1000000
  timeline = [0] * (maxT+1)

  for _ in range(n):
    start, end = map(int, f.readline().split())
    timeline[start] += 1
    timeline[end] -= 1

curPas = maxPas = activeTime = 0

for t in range(maxT):
  curPas += timeline[t]

  if curPas > maxPas:
    maxPas = curPas

  if curPas > 0:
    activeTime += 1

print(f"{maxPas} {activeTime}")

