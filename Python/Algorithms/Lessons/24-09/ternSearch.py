from random import randint

A = [randint(1, 100) for _ in range(10)]
print("Изначальный массив:", *A)
A.sort()
print("Отсортированный массив:", *A)

l, r = 0, len(A)

x = int(input("Введите искомое число X: "))

while r >= l:
    m1 = (2*l + r) // 3
    m2 = (2*r + l) // 3
    if A[m1] == x or A[m2] == x:
        if A[m1] == x:
            print(m1)
        else:
            print(m2)
        break
    if A[m1] > x:
        r = m1-1
    elif A[m2] < x:
        l = m2+1