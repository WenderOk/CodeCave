E = input()
a = int(E[:E.find("x")])
b = int(E[E.find("+")+1:E.find("=")])
print(-b / a)