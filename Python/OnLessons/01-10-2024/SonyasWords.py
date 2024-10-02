word = input("Введите слово: ")
n = int(input("Введите число: "))
if word[-n:] == word[:n][::-1]: print("YES")
else: print("NO")
