import numpy as np
import timeit
A_list = [np.random.randn() for _ in range(10000)]
B_list = [np.random.randn() for _ in range(10000)]
A = np.array(A_list)
B = np.array(B_list)
%timeit
C = A + B
%%timeit
C = [0]*len(A_list)
for i in range(len(A_list)):
    C[i] = A_list[i] + B_list[i]