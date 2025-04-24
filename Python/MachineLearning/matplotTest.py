import matplotlib.pyplot as plt
from math import *

data=[]
for i in range(1000): 
    data.append(sqrt(i)**2+123*sqrt(i)+45)

plt.plot(data)
plt.show()