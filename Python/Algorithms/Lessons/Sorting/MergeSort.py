def merge(A, B):
    result = []
    i = j = 0  

    while i < len(A) and j < len(B):
        if A[i] <= B[j]:
            result.append(A[i])
            i += 1
        else:
            result.append(B[j])
            j += 1
    while i < len(A):
        result.append(A[i])
        i += 1
    while j < len(B):
        result.append(B[j])
        j += 1

    return result

a = [1, 5, 7, 12, 13]
b = [2, 4, 8, 9]
print(merge(a, b)) 
