N = int(input())
A = map(int, input().split())

c10 = c2 = c5 = 0

for n in A:
    if n % 10 == 0: c10 += 1 
    elif n % 5 == 0: c5+=1
    elif n % 2 == 0: c2+=1

c = c10 *(N-c10) + c2*c5
print(c)

