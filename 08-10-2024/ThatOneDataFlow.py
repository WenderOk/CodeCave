"""
n, s, i = int(input()), 0, 0
while n != 0:
    if n % 5 == 0 and 9 < n < 100: 
        s += n
        i +=1
    n = int(input())
print("нет" if s==0 else s/i)
"""
from math import log2
n, s, i = int(input()), 0, 0
while n != 0:
    if log2(n) == 1 and int(log2(n)) == n: 
        s += n
        i +=1
    n = int(input())
print("нет" if s==0 else s/i)