import copy

def det(matrix):
    a11,a12,a13 = matrix[0]
    a21,a22,a23 = matrix[1]
    a31,a32,a33 = matrix[2]

    return a11*(a22*a33-a23*a32)-a12*(a21*a33-a31*a23)+a13*(a21*a32-a22*a31)

def parTermDet(matrix,frTerm):
    prDet=[]
    for i in range(3):
        tmpMat = copy.deepcopy(matrix)
        for j in range(3):
            tmpMat[j][i] = frTerm[j]
        prDet.append(det(tmpMat))
    return prDet

def solveSys(prDet, mainDet):
    detX,detY,detZ = prDet
    x,y,z = detX//mainDet,detY//mainDet,detZ//mainDet
    return x,y,z

matrix=[0]*3

print("Enter 3x3 matrix by row separating numbers with space")
for i in range(3): matrix[i] = list(map(int, input(f"Row {i+1}: ").split()))
frTerm = list(map(int, input("Enter 3x3 matrix of free terms separating numbers with space: ").split()))

prDet = parTermDet(matrix,frTerm)
mainDet = det(matrix)
if mainDet == 0: 
    print("\nSystem doesn't have single solution (the determinant is zero)")
    exit()

print(f"\nMain determinant = {mainDet}\n")
print(f"""Partial determinants
det x = {prDet[0]}
det y = {prDet[1]}
det z = {prDet[2]}\n""")

x,y,z = solveSys(prDet,mainDet)

print(f"""System solution
x = {x}
y = {y}
z = {z}""")