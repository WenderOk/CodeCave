# Для ручного ввода множества
# A = set([int(x) for x in (input("Enter set: ")).split()])
A={10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30}

def IsEven(number):
    return number % 2 == 0
def IsMult5(number):
    return number % 5 == 0
def IsPrime(n):
    if n <= 1:
        return False
    if n <= 3:
        return True
    if n % 2 == 0 or n % 3 == 0:
        return False
    i = 5
    while i * i <= n:
        if n % i == 0 or n % (i + 2) == 0:
            return False
        i += 6
    return True


def CreateEven(M1):
    M2 = set()
    for i in M1:
        if IsEven(i): M2.add(i)
    return M2

def CreateM5(M1):
    M2 = set()
    for i in M1:
        if IsMult5(i): M2.add(i)
    return M2

def CreatePrime(M1):
    M2 = set()
    for i in M1:
        if IsPrime(i): M2.add(i)
    return M2


def notM(M1,M2):
    return M1.difference(M2)

def funcAnd(M1,M2):
    return M1.intersection(M2)
def funcOr(M1,M2):
    return M1.union(M2)
def funcImp(M1,M2):
    return M2.difference(M1).union(M2)
def funcEq(M1,M2):
    return len(M1) == len(M2)

B = CreateEven(A)
C = CreateM5(A)
D = CreatePrime(A)

notB = notM(A,B)
notC = notM(A,C)
notD = notM(A,D)

print(f"A: {A}\n\nB: {B}\nnot B: {notB}\nC: {C}\nnot C: {notC}\nD: {D}\nnot D: {notD}\n")

print(f"funcAnd: {funcAnd(A,B)}\nfuncOr: {funcOr(A,B)}\nfuncImp: {funcImp(A,B)}\nfuncEq: {funcEq(A,B)}")
