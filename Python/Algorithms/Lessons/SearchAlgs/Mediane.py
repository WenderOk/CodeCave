N = int(input())
A = [int(a) for a in input().split()]
M = int(input())
B = [int(b) for b in input().split()]
res = [0] * len(B)

i = 0
for j in range(len(B)):
    while A[i] < B[j]:
        i += 1
    if A[i] == B[j]:
        L = i
        while i+1 < len(A) and A[i]+1 == B[j]:
            i+=1
        R = i
        res[j] = (L + R) // 2 + 1
print(*res)

