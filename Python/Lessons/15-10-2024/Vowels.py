vowels = "АОЕЁЭУЮИЫЯ "
s = input().upper()
newS=""
for i in s:
    if i not in vowels: newS+=i
print(newS)