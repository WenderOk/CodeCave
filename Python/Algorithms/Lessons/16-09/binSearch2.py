from random import randint;

def binSearch(A, n):
    lb = 0
    rb = len(A)-1
    mid = rb // 2
    c = 0

    while lb + 1 < rb:
        mid = lb + (rb - lb) // 2
        c += 1
        if n == A[mid]:
            return mid
            break
        elif n > A[mid]:
            lb = mid + 1
        else:
            rb = mid - 1


arr = [randint(1, 100) for _ in range(100)]
print(arr)
arr.sort()
print(arr)
print("Enter number to find: ")
x = int(input())
print(binSearch(arr, x))

