m, x = -101, int(input())
while x !=0:
    if x in range(-100, 100+1) and x % 2 == 0 and x > m: m = x
    x=int(input())
if m != -101: print(m)
else: print("нет")