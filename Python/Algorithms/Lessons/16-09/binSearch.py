def binSearch(A, n):
    lb = 0
    rb = 0
    mid = rb // 2

    while lb <= rb:
        mid = lb + (rb - lb) // 2
        if n == A[mid]:
            return mid
        elif n > A[mid]:
            lb = mid+1
        else:
            rb = mid-1
        if lb > rb:
            return -1


arr = [int(a) for a in input().split()]
binSearch(arr, 4)
