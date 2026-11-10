from random import randint
import time

N = 5000
cases = [
    list(range(1, N + 1)),
    list(range(N, 0, -1)),
    [randint(1, 1000) for _ in range(N)],
    list(range(2, N + 1)) + [1],
    [randint(1, 5) for _ in range(N)],
]

def shaker(A):
    swapped = True
    l, r = 0, len(A)-1
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

def bubble(A):
    for i in range(len(A)):
        flag = False
        for j in range(0, len(A) - i - 1):
            if A[j] > A[j + 1]:
                A[j], A[j + 1] = A[j + 1], A[j]
                flag = True
        if not flag: break

for case in cases:
    startTime = time.perf_counter()
    bubble(case.copy())
    endTime = time.perf_counter()
    bubbleTime = endTime - startTime
    
    startTime = time.perf_counter()
    shaker(case.copy())
    endTime = time.perf_counter()
    shakerTime = endTime - startTime

    print("bubble time: ", bubbleTime)        
    print("shaker time: ", shakerTime)

