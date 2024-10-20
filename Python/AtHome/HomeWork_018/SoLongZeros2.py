# Вариант программы, который переводит введенное в десятичной системе счисления число в число 
# в пятиричной системе счисления
n,mx,c,s = int(input()),-1,0,''
while n > 0:
    s+=str(n%5)
    n//= 5
n=int(s)
print(n)
for _ in range(len(str(n))):
    if n % 10 == 0: c+=1
    else: c = 0
    n //= 10
    if c>mx: mx=c
print(mx)