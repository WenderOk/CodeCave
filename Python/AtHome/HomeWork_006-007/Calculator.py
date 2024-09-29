# Знаю что говнокод, но пока так
a,b,operator = float(input("Введите первое число: ")), float(input("Введите второе число: ")), input("Введите операцию: ")
if b==0 and (operator == "mod" or operator == "div" or operator == "/"):
    print("Деление на 0!")
    quit() # Да, я знаю что мы это не проходили еще, но с ним удобнее и никаких ограничений в задании не было :)
else: 
    if operator == "mod": 
        print(a % b)
        quit()
    elif operator == "div": 
        print(a // b)
        quit()
    elif operator == "/": 
        print(a / b)
        quit()
if operator == "+": 
    print(a + b)
    quit()
elif operator == "-": 
    print(a - b)
    quit()
elif operator == "pow": 
    print(a ** b)
    quit()
elif operator == "*": 
    print(a * b)
    quit()
else: print("Введена некоректная операция!")