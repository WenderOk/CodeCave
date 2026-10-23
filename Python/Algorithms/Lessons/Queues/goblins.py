N = int(input())

queue = []
for i in range(N):
    s = input().split()
    if s[0] == "+": 
        queue.append(s[1])
    elif s[0] == "*":
        md = len(queue)//2
        queue = queue[:md] + [s[1]] + queue[md:]
    elif s == "-":
        x = queue.pop()
        print("Вышел: ", x)

print("Итоговая очередь: ", *queue)

