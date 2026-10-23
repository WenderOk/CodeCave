N = int(input())
A = map(int, input().split())

ce, co = 0, 0

for n in A:
    if n % 2 == 0: ce+=1
    else: co+=1

print((ce*(ce-1))//2 + (co*(co-1))//2)

