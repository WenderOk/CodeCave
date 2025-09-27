import matplotlib.pyplot as plt
from math import *
from random import *

x1,x2, f = randint(-100,0), randint(0,100), []
for x in range(x1,x2): 
    f.append(-1/(1+e**x))

plt.plot(f)
plt.show()

