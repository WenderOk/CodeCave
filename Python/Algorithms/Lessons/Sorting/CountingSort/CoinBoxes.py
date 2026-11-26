with open('/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Sorting/26-J1.txt') as f:
    n = int(f.readline())
    boxes = [0] * 100
    for _ in range(n):
        k = int(f.readline())
        boxes[k] += 1

c = 0
for k in range(1, 50):
    c += min(boxes[k], boxes[100 - k])

c += boxes[50] // 2

print(c)

