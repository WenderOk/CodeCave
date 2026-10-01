import sys
sys.setrecursionlimit(10**6)

def F (start, finish):
    if start == finish:
        return 1
    if finish < start or finish == 21:
        return 0
    c = F(start, finish-1)
    if finish % 3 == 0:
        c += F(start, finish//3)
    if finish % 4 == 0:
        c += F(start, finish//4)
    return c

print(F(2, 16) * F(16, 62))

