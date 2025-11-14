N,mn = int(input("Введите количество чисел в последовательности: ")),float('inf')
for i in range(N):
    a = int(input())
    if a % 9 != 0 and a < mn: mn = a
print(mn)