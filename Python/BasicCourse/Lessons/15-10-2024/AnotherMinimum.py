mn, x = float('inf'), int(input())
while x !=0:
    if x > 0 and abs(x) in range(10, 100) and abs(x)%10==6: m = x
    x=int(input())
if mn != float('inf'): print(f"Ответ: {mn}")
else: print("Ответ нет")