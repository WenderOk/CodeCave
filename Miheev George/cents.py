rub, cop, pieAmount = map(int, input("Введите цену пирожка, количество рублей, копеек и пирожков через пробел: ").split())
cop = (cop + rub * 100) * pieAmount
print("К оплате: {} руб. {} к.".format(cop // 100, cop % 100))