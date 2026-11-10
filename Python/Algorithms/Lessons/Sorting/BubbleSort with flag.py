from random import randint

N = 10
A = [randint(1, 100) for _ in range(N)]

print(A)

for i in range(N-1):
    is_sorted = True
    for j in range(N-i-1):
        if A[j] > A[j+1]:
            A[j], A[j+1] = A[j+1], A[j]
            is_sorted = False
            
    if is_sorted:
        break
swapped = True; i = 0
while swapped and i < N:
    swapped = False
    for j in range(N-i-1):
        if A[j] > A[j+1]:
            A[j], A[j+1] = A[j+1], A[j]
            swapped = True
            
    if not swapped:
        break
    i += 1

print(A)