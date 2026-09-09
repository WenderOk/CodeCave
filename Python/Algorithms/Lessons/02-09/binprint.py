def printBin(n):
    if n < 1: 
        print()
    elif n >=1:
        printBin(n // 2)
        print(n % 2, end="")
printBin(15)
printBin(16)