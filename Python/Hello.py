from random import*
N = int(input())
c, A = 0, [randint(-100, 100) for _ in range(N)]
for _ in range(A.count(0)): A.remove(0)
for i in range(len(A)):
    if ((A[i] > 0 and A[i-1] < 0) or (A[i] < 0 and A[i-1] > 0)): c+=1
print(A, '\n', c, sep='')