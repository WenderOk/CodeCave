import os
import sys
import time
from decimal import Decimal, getcontext
from multiprocessing import Pool

def calc_chunk(st, en):
    r= Decimal(0)
    for i in range(st, en):
        c = 8*i
        t1 = Decimal(4)/(c + 1)
        t2 = Decimal(2)/(c + 4)
        t3 = Decimal(1)/(c + 5)
        t4 = Decimal(1)/(c + 6)
        t5 = Decimal(1)/16**i
        r += t5 * (t1 - t2 - t3 - t4)
    return r

def _worker_wrapper(args):
    start, end, precision, = args
    getcontext().prec = precision
    return calc_chunk(start, end)

def compute(n, step=100):
    res = Decimal(0)
    getcontext().prec = n
    
    prev_i = 0
    tasks = []
    for i in range(0, n+step, step):
        tasks.append((prev_i, i, n))
        prev_i = i
    with Pool(processes=os.cpu_count()) as pool:
        results = pool.map(_worker_wrapper, tasks)

    for r in results:
        res += r
    return res

if __name__ == "__main__":
    n = int(input("Enter n: "))
    getcontext().prec = n
    t_start = time.time()
    res = compute(n)
    t_end = time.time()-t_start
    print(str(res))
    print(t_end)
