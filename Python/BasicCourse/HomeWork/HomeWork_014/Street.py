a,b = int(input("Введеит номер первого дома: ")), int(input("Введеит номер второго дома: "))
if a or b == 1: print((b-a)//2)
elif (a%2==0 and b%2!=0) or (a%2!=0 and b%2==0): print((b-a)//2+1)
else: print((b-a)//2)