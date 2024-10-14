n = int(input("Введите число N: "))
if n == (n**2) % 10**len(str(n+1)): print(f"{n} * {n} = {n**2}")