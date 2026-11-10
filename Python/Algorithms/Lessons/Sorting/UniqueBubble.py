from random import randint

n = 10
arr = [randint(1, 100) for _ in range(n)]

c = 0

for i in range(n):
    for j in range(n - i - 1):
        if arr[j] > arr[j + 1]:
            arr[j], arr[j + 1] = arr[j + 1], arr[j]
            
    if i > 0 and arr[i] != arr[i-1]:
        c+=1

if arr[i] != arr[i-1]:
    c+=1

print(arr)
print(c)