n = int(input("Введите количество пингвинов: "))
if not(1 <= n <= 9):
    print("У нас нет столько пингвинов -_-")
else:
    for i in range(n):
        print("  _~_    ", end="")
    print("")
    for i in range(n):
        print(" (o o)   ", end="")
    print("")
    for i in range(n):
        print(" / V \\   ", end="")
    print("")
    for i in range(n):
        print("/( _ )\\  ", end="")
    print("")
    for i in range(n):
        print(" ^^ ^^   ", end="")
    print("")