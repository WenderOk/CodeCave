eq = input()
xIndex = eq.find("x")
a = 1 if eq[:xIndex] == '' else int(eq[:xIndex])
b = 0 if eq[xIndex+1:eq.find("=")] == '' else int(eq[xIndex+1:eq.find("=")])
if a and b == 0: print('INF')
elif a==0 and b!=0: print('NO')
else: print(round((-b/a),2))

# Тернарный оператор оказывается классная штука