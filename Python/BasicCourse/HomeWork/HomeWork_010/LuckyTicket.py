code = input("Введите номер билета: ")
h1, h2 = 0,0
for i in range(3):
    h1 += int(code[i])
for i in range(4):
    h2 += int(code[-i])
if h1 == h2: print("Счастливый")
else: print("Обычный")
