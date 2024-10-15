s1,s2 = input(), input()
h=0
for i in range(len(s1)):
    if s1[i] != s2[i]: h+=1
print(h)