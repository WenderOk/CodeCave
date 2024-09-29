a,b,operator = float(input("Введите первое число: ")), float(input("Введите второе число: ")), input("Введите операцию: ")
if b==0 and (operator == "mod" or operator == "div" or operator == "/"):
    print("Деление на 0!")
    quit()
else: 
    if operator == "mod": print(a%b)
    elif operator == "div": print(a//b)
    elif operator == "/": print(a/b)
if operator == "+": print(a+b)
elif operator == "-": print(a-b)
elif operator == "pow": print(a**b)
elif operator == "*": print(a*b)
else: print("Введена некоректная операция!")