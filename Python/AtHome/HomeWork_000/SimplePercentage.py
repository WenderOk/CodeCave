n = int(input("Введите сумму вклада: "))
p = int(input("Введите процентную ставку: "))
n = n*(1+round(p/100,2))*100
print(int(n//100),int(n%100))