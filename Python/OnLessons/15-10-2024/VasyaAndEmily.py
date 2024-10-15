s, i = input(), input(),
while i != "стоп":
    i = int(i)
    s = s[:i]+"."+s[i+1:]
    i = input()
print(s)