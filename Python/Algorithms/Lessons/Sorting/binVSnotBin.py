from random import randint
import time

class HeavyObject:
    def __init__(self, value: int, delay_loops: int = 3000):
        self.value = value
        self.delay_loops = delay_loops

    def __lt__(self, other):
        if not isinstance(other, HeavyObject):
            return NotImplemented
        for _ in range(self.delay_loops):
            pass
        return self.value < other.value

def insertSort(A):
    for i in range(1, len(A)):
        key = A[i]  # Текущий элемент для вставки
        j = i - 1
        
        # Сдвигаем элементы, которые больше key, на одну позицию вправо
        while j >= 0 and A[j] > key:
            A[j + 1] = A[j]
            j -= 1
            
        A[j + 1] = key  # Вставляем key на найденное место
    return A


def binInsertSort(A):
    for i in range(1, len(A)):
        x = A[i]
        l,r = 0,i

        while l < r:
            mid = l + (r-l)//2
            if A[mid] < x:
                l = mid + 1
            else:
                r = mid

        A[l+1:i+1] = A[l:i]
        A[l] = x
    return A

A = [HeavyObject(randint(1, 100)) for _ in range(100)]

startTime = time.perf_counter()
insertSort(A.copy())
endTime = time.perf_counter()
insertTime = endTime - startTime

startTime = time.perf_counter()
binInsertSort(A.copy())
endTime = time.perf_counter()
binInsertTime = endTime - startTime

print("Vanilla:", insertTime)
print("Modded:", binInsertTime)


