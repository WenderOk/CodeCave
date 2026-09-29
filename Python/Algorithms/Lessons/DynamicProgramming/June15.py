K = [0]*(21+1)
K[1] = 1
for i in range(2, 21+1):
    K[i] = K[i-1]
    if i % 2 == 0 and (i <= 10 or i//2 >= 10):
        K[i] += K[i//2]
print(K[21])