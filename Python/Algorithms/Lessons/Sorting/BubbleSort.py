from random import randint

N = 10
A = [randint(1, 100) for _ in range(N)]

print(A)

for i in range(N-1):
    flag = False
    for j in range(N-i-1):
        if A[j] > A[j+1]:
            A[j], A[j+1] = A[j+1], A[j]
            flag = True
            
    if not flag:
        break

print(A)