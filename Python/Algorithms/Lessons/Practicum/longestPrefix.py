def prefix(a, b):
    pref = []
    for i in range(len(min(a,b, key=len))):
        if a[i] == b[i]:
            pref.append(a[i])
        else:
            break
    return pref

words = input().split(', ')
pref = words[0]
for i in range(1, len(words)):
    pref = prefix(pref, words[i])
print("".join(pref))

words = input().split(', ')
words.sort()
pref = words[0]; m = words[-1]
if len(m) < len(pref):
    pref, m = m, pref
for i in range(len(pref)):
    if pref[i] != m[i]:
        break
pref = pref[:i]
print(pref)

