from random import randint

n = 1000
A = [randint(1, 100) for _ in range(n)]

def bubble(A):
    c = 0
    for i in range(n):
        flag = False
        for j in range(n - i - 1):
            if A[j] > A[j + 1]:
                A[j], A[j + 1] = A[j + 1], A[j]
                c+=1
                flag = True
        if not flag: break

    return c

def select(A):
    c = 0
    for i in range(n-1):
        nMin = i
        for j in range(i+1, n):
            if A[j] < A[nMin]:
                nMin = j

        if i != nMin:
            A[i], A[nMin] = A[nMin], A[i]
            c+=1
    
    return c

print("Bubble:", bubble(A.copy()))
print("Select:", select(A))
