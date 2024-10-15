mn,mx,x=float('inf'),float('-inf'),int(input())
while x !=0:
    if x < mn: mn=x
    elif x > mx: mx=x
    x=int(input())
print(f"Минимум: {mn}")
print(f"Максимум: {mx}")