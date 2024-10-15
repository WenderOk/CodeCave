N, x, y = int(input("Введите количество чисел: ")), 0, 0
for _ in range(N):
    com, a = input().split()
    a=int(a)
    if com == "север": y+=a
    elif com == "юг": y-=a
    elif com == "восток": x+=a
    elif com == "запад": x-=a
    else: print("Введена неверная команда!")
print(x,y)