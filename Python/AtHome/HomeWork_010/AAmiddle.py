s = input("Введите слово латинскими буквами: ")
if s == "": print("Я сказал введите слово")
else:
    if s[len(s)//2] == "A" and s[len(s)//2+1] == "A" or s[len(s)//2] == "A" and s[len(s)//2-1] == "A": print("+")
    else: print("-")