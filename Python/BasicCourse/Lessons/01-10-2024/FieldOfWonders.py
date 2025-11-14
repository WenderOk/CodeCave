word = input("Введите загаданное слово: ")
n = int(input("Введите количество угаданных букв: "))
print(word[:n] + (len(word)- 2*n) * "." + word[-n:])
