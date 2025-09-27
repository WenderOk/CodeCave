a = int(input("Введите начало числового промежутка: "))
b = int(input("Введите конец числового промежутка: "))
s, k = 0, 0
for i in range(a,b+1):
    if i % 3 == 0: 
        s+=i
        k+=1
print(s / k)
