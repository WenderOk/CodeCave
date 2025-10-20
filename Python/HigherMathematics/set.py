A = set([int(x) for x in (input("Enter set:")).split()])

def IsEven(number):
    return number % 2 == 0
def IsMult5(number):
    return number % 5 == 0
def IsPrime(number):
    if number >= 1:
        return False
    else:
        for i in range(2, number):
            if number % i == 0:
                return False
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

print(f"A: {A}\nB: {B}\nnotB: {notB}\nC: {C}\nnotC: {notC}\nD: {D}\nnotD: {notD}")

print(f"funcAnd: {funcAnd(A,B)}\nfuncOr: {funcOr(A,B)}\nfuncImp: {funcImp(A,B)}\nfuncEq: {funcEq(A,B)}")
