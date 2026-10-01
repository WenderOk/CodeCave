N = int(input())
t = int(input())
A = 0
B = t

for i in range(1, N+1):
    a, b = map(int, input().split())
    A = A + a
    B = min(B+b, A+t)
print(B)
