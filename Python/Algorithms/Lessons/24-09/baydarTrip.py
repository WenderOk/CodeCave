N, D = map(int, input().split())
A = [int(n) for n in input().split()]
i, j = 0, N-1
num = 0

while j >= i:
    if A[j] + A[i] <= D:
        i+=1    
    j-=1
    num+=1
        
print(num)
