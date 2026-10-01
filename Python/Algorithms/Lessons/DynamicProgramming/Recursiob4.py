# def F (start, finish):
#     if start == finish:
#         return 1
#     if start > finish:
#         return 0
#     return F(start+2, finish) + F(start*2, finish)

def F (start, finish):
    if start >= finish:
        return start == finish
    c = F(start, finish-2)
    if finish % 2 == 0:
        c += F(start, finish//2)
    return c

print(F(2, 20) * F(20, 160))

