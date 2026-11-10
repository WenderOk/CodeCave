from random import randint

def digSum(x):
    s = 0
    while x > 0:
        s += x%10
        x //= 10
    return s

N = 10
A = [randint(1, 100) for _ in range(N)]
print(A)

for i in range(N-1):
    flag = False
    for j in range(N-2, i-1, -1):
        if digSum(A[j]) > digSum(A[j+1]):
            A[j], A[j+1] = A[j+1], A[j]
            flag = True            
    if not flag:
        break
    

print(A)
