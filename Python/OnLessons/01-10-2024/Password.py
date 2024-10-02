pswd = input("Введите пароль: ")
if len(pswd) < 6: print("Пароль слишком короткий!")
elif pswd[:6] == "qwerty": print("Ненадежный пароль!")
else: print("Все ОК")