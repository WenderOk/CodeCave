a,b,v = map(int,input().split())
name = ""
if a < b < v: name = "Виктор"
elif a<b: name = "Борис"
else: name = "Антон"
print(name,"старше всех")


