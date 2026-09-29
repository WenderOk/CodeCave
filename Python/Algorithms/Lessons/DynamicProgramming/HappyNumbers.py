N = int(input())
A = 0

def f(A):
    return A - A//13 - A//17 + A//221

lb = 0
rb = N*2
mid = lb + (rb - lb) // 2
while rb >= lb:
    mid = lb + (rb - lb) // 2
    n = f(mid)
    if n == N:
        print(mid)
        break
    elif n < N:
        lb = mid + 1
    else:
        rb = mid - 1