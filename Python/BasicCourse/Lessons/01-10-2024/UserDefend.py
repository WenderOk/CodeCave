while True:
    print("Укажите ваш пол(Ж\М\Д): ", end=" ")
    gender = str(input())
    if gender == "Ж" or gender == "М" or gender == "Д": break
    else: print("Укажите пол из списка!")