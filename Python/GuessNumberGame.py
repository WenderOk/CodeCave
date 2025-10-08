from random import randint
from math import log

maxAttempts=10
attempts=10
diff=1

def calcAttempts(maxAttempts,diff):
    attempts = int(maxAttempts - 2 * log(diff))
    return max(1, round(attempts))

def game(attempts):
    number=randint(0,100)
    print("Угадайте число от 0 до 100: ")
    for i in range(attempts):
        print(f"Попыток осталось: {attempts-i}")
        n=int(input())
        if n==number:
            print("Вы угадали!")
            break
        else: print(f"Попробуйте еще раз.")
    else: print(f"Попытки закончились\nЗагаданным числом было: {number}\n")

menuItem=0

while menuItem!=3:
    print(f"""Игра угадайте число
    1. Начасть игру
    2. Установить уровень сложности (текущий уровень {diff})
    3. Выйти""")
    menuItem=int(input("Выберете действие: "))
    if menuItem==1: game(calcAttempts(maxAttempts, diff))
    elif menuItem==2: diff = int(input("Введите уровень сложности: "))
    