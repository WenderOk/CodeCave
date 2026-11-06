from random import randint

A = [5, 3, 4, 2, 1, 6, 3, 2, 4]
N = len(A)
c = 0

for i in range(N-1):
    nMin = i
    for j in range(i+1, N):
        if A[j] < A[nMin]:
            nMin = j

    if i != nMin:
        A[i], A[nMin] = A[nMin], A[i]

    if i == 0 or A[i] != A[i-1]:
        c+=1

if A[-1] != A[-2]:
    c+=1    

print(*A)
print(c)

