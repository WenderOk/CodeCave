def F(t):
    if t <= 1:
        return t == 1
    c = F(t-2)
    if t % 2 == 0:
        c += F(t//2)
    return c

print(F(24))

