value = 0
for a in range(1, 100+1):
    for b in range(a, 100+1):
        for c in range(1, 100+1):
            if a**2 + b**2 == c**2: value+=1
print('Всего прямоугольных треугольников со сторонами не больше 100:',value)