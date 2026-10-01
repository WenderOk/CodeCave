def F(t):
    if t == 1:
        return 1
    c = F(t-1)
    if t % 4 == 0:
        return c + F(t//4)
    else:
        return c

print(F(32))

