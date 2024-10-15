N=123
a = N // 100; b = N // 10 % 10; c = N % 10
print(N)
for i in range(1,3):
    print('\t'*i, (a+i)%10, (b+i)%10, (c+i)%10, sep="")