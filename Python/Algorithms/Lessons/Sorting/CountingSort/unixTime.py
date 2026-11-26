with open(r"C:\Users\TOP\source\repos\WenderRPO\CodeCave\Python\Algorithms\Lessons\Sorting\CountingSort\26.txt") as f:
  n = int(f.readline())
  mn = 1633305600
  period = 7*24*3600
  timeline = [0] * (period+1)

  for _ in range(n):
    start, end = map(int, f.readline().split())
    if end == 0: end = mn+period
    if end < mn or start > mn+period:
      continue
    if start < mn: start = mn
    if not end > mn+period: 
      timeline[end-mn] -= 1
    timeline[start-mn] += 1

curProc = maxProc = activeTime = 0
for t in range(period):
  curProc += timeline[t]
  if curProc > maxProc:
    maxProc = curProc

  if curProc > 0:
    activeTime += 1

print(f"{maxProc} {activeTime}")


