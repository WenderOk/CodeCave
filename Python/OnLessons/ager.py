a=int(input("Введите свой возраст: "))
word = ""
a%=100
if not(11 <= a <= 20):
    if a%10==1: word = "год"
    elif 2 <= a % 10 < 5: word="года"
else: word = "лет"
print("Вам",a,word)

