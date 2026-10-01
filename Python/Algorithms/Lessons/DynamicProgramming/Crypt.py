A = int(input())
c = 1
prev = 100

while A > 0:
    d = A % 10
    if d != 0 and 10 * d + prev <=33:
        c+=c
    A//=10
    prev = d
print(c)

