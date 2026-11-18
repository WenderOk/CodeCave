def generateSedgewickGaps(N):
    gaps = []
    k = 0
    while True:
        if k % 2 == 0:
            gap = 9 * (2**k) - 9 (2**(k//2)) + 1
        else:
            gap = 8 * ()

def shellSort(A):
    N = len(A)
    gaps = generateSedgewickGaps(N)[::-1]
    for gap in gaps:
        for i in range(gap, N):
            key = A[i]
            j = i
            while j >= gap and A[j - gap] > key:
                A[j] = A[j - gap]
                j -= gap
            A[j] = key
    return A