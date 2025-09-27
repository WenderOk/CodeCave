a,b,c,d = map(int,input().split())
Mi1, Ma1, Mi2, Ma2 = 0, 0, 0, 0
if a<b: Mi1, Ma1 = a, b
if c<d: Mi2, Ma2 = c, d
if Ma1 > Ma2: print(Ma1)
else: print(Ma2)
if Mi1 > Mi2: print(Mi2)
else: print(Mi1)