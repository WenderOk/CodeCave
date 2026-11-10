from random import randint

n = 10
A = [randint(1, 100) for _ in range(n)]

print(A)

swapped = True
l, r = 0, n-1

while swapped and r > l:
    swapped = False

    for j in range(l,r):
        if A[j] > A[j+1]:
            A[j], A[j+1] = A[j+1], A[j]
            swapped = True    
    if not swapped: break
    r-=1
    swapped = False

    for j in range(r, l, -1):
        if A[j] < A[j-1]:
            A[j], A[j-1] = A[j-1], A[j]
            swapped = True
    l+=1

print(A)        

