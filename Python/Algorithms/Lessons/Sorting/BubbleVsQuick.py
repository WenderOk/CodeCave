import random

def bSort(a):
    swaps = 0
    n = len(a)
    for i in range(n - 1):
        swapped = False
        for j in range(n - 1 - i):
            if a[j] > a[j + 1]:
                a[j], a[j + 1] = a[j + 1], a[j]
                swaps += 1
                swapped = False
        if not swapped: break
    return swaps

def sSort(a):
    swaps = 0
    n = len(a)
    for i in range(n - 1):
        min_idx = i
        for j in range(i + 1, n):
            if a[j] < a[min_idx]:
                min_idx = j
            if min_idx != i:
                a[i], a[min_idx] = a[min_idx], a[i]
                swaps += 1
    return swaps

N = 1000 
loops = 10

bubbleTotal = 0
selectTotal = 0

for _ in range(loops):
    A = [random.randint(1, 10000) for _ in range(N)]
    bubbleTotal += bSort(A.copy())
    selectTotal += sSort(A.copy())

avgB = bubbleTotal / loops
avgS = selectTotal / loops

print(f"Количество тестов: {loops}, размер массива: {N}")
print(f"Среднее число перестановок (пузырьковая сортировка): {avgB:.1f}")
print(f"Среднее число перестановок (сортировка выбором): {avgS:.1f}")
