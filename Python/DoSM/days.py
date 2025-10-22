def days_to_word(number):
    if number == 1:
        return "день"
    elif number % 10 == 1 and number != 11:
        return "день"
    elif number % 10 in range(2, 5) and number not in range(12, 15):
        return "дня"
    else:
        return "дней"
    
print(days_to_word(int(input("Enter amount of days: "))))
