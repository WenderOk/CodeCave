m=int(input())
if m!=0 and m<=12:
    if (m%12)<3: print("Зима")
    elif 3 <= m <= 5: print("Весна")
    elif 6 <= m <= 8: print("Лето")
    elif 9 <= m <= 11: print("Осень")
else: print("Недействительный месяц")