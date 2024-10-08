n, i = int(input()), 0
oldN = n
while n != 0:
    if abs(n) % 10 == 6: i+=1
    n//=10
if i <= 3: print("Bad number")
else: print(oldN)