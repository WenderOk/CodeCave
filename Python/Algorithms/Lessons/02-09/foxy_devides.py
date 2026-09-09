c = 0
num = 7000000
while c != 5:
    num+=1
    d = 2
    while d*d <= num:
        if num % d == 0:
            sm = num // d + d
            if sm % 10 == 8:
                print(num, sm)
                c +=1
            break
        d+=1
