for x in range(20):
    for y in range(50):
        if x == 9: print("-", end="") 
        elif 28+x==y: print("\\",end="")
        elif 20-x == y: print("/",end="")
        elif y == 24: print("|", end="")
        else: print(" ", end="")
    print()

