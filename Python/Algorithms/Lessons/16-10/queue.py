N = int(input())
A = [int(x) for x in input().split()]
next_stud = [0]*(N+1)
for i in range(1, N+1):
    next_stud[A[i-1]], next_stud[i] = i, next_stud[A[i-1]]
j = 0; out = ""
while next_stud[j] < N + 1:
    j = next_stud[j]; out += str(j) + " "
print(out.rstrip())