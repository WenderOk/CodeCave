N, D = map(int, input().split())
A = [int(n) for n in input().split()]
i, j = 0, 0
num = 0

while j < N and i < N:
    if A[j] - A[i] < D:
        j+=1
    else:
        num += N-j
        i+=1
print(num)
