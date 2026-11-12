from random import randint

def qSort(A, start, end):
    if start >= end: 
        return
    l = start
    r = end
    x = A[randint(l, r)]
    
    while l <= r:
        while A[l] > x: l += 1
        while A[r] < x: r -= 1
            
        if l <= r:
            A[l], A[r] = A[r], A[l]
            l += 1
            r -= 1            
    qSort(A, start, r)
    qSort(A, l, end)

def qSortUniq(A):
    if not A: return 0
        
    qSort(A, 0, len(A) - 1)
    
    c = 1
    for i in range(1, len(A)):
        if A[i] != A[i - 1]:
            c += 1
    return c

n = 10
a = [randint(1, 10) for _ in range(n)]
print(a)

count = qSortUniq(a)
print(a)
print(count)
