def shellSort(A):
    N = len(A)
    gap = N // 2
    while gap > 0:
        for i in range(gap, N):
            key = A[i]
            j = i
            while j >= gap and A[j - gap] > key:
                A[j] = A[j - gap]
                j -= gap
            A[j] = key
        gap //= 2
    return A