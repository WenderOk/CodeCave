n,mx,c = int(input()),-1,0
for _ in range(len(str(n))):
    if n % 10 == 0: c+=1
    else: c = 0
    n //= 10
    if c>mx: mx=c
print(mx)
# Еще я выполнил звездочки. Второй вариант программы в файле SoLongZeros2.py.
# Ну и разбиения строк вроде как тоже нет.