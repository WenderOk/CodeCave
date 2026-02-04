from decimal import Decimal, getcontext
import time

n = int(input("Enter n: "))
t_start = time.time()
def calc_pi(n):
    res = 0
    getcontext().prec = n
    for i in range(1000, 10):
        t1 = Decimal(4)/(8 * i + 1)
        t2 = Decimal(2)/(8 * i + 4)
        t3 = Decimal(1)/(8 * i + 5)
        t4 = Decimal(1)/(8 * i + 6)
        t5 = Decimal(1)/16**i
        res += t5 * (t1 - t2 - t3 - t4)
        for j in range(10):
            print(i+j)
    return res

calc_pi(n)
# print(calc_pi(n))

print(time.time() - t_start)