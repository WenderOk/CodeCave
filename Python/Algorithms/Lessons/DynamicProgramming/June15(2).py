K = [0]*(50+1)
K[4] = 1
for i in range(5, 50+1):
    if i == 12:
        continue
    K[i] = K[i-1]
    if i % 3 == 0 and (i <= 6 or i//3 >= 6):
        K[i] += K[i//3]
print(K[50])