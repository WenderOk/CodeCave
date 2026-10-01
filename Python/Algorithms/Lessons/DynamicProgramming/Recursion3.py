def F(t):
    if t <= 3:
        return t == 3
    c = F(t-3) + F(t-1)
    if t % 2 == 0:
        c += F(t//2)
    return c

print(F(15))

