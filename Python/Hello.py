A, B = [x for x in input("Введите исходную строку: ")], []
#if A[-1] == A[0]: B.append(A[0])
for i in range(len(A)):
    if A[i] != A[i+1]: B.append(A[i])
print(*A, sep="")
print(*B, sep="")