a,e,n = input("Введите число: "),0,0
for d in a:
    if d == "1": e+=1
    elif d == "0": n+=1
    else: print("Неправильный символ!")
print(f"Нулей: {n}")
print(f"Едениц: {e}")