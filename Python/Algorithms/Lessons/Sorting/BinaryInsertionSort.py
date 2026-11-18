from random import randint

def binInsertSort(A):
    for i in range(1, len(A)):
        x = A[i]
        l,r = 0,i

        while l < r:
            mid = l + (r-l)//2
            if A[mid] < x:
                l = mid + 1
            else:
                r = mid

        A[l+1:i+1] = A[l:i]
        A[l] = x
    return A

A = [randint(1, 100) for _ in range(10)]

print(binInsertSort(A))