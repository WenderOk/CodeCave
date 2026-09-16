W = 41
C = list(range(0, W))
i = 2
itrs = 0
while len(C) > 1:
    del C[i % len(C)]
    i += 2
    itrs += 1
print(itrs)
print(C)


