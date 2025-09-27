s="7"*84
while '727' in s or '7777' in s:
    s=s.replace('7777','72',1).replace('727','7',1)
print(s)