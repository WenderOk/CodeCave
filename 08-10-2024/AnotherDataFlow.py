n, s = int(input()), 0
while n != 0:
    if n % 3 == 0 and n % 10 == 1: s += n
    n = int(input())
if s != 0: print(s)
else: print("нет")