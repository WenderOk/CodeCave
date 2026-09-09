def recSum(A):
    if A == []:
        return 0
    else:
        return A[0] + recSum(num[1:])
    