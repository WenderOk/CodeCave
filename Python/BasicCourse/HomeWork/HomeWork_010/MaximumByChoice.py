a,b,c,d,M,ToF = int(input("Введите число А: ")), int(input("Введите число B: ")), int(input("Введите число C: ")), int(input("Введите число D: ")), 0,0
ToF += a>b and a>c and a>d
if ToF == 1: 
    M = a
    ToF=0
    print(M)
ToF += b>a and b>c and b>d
if ToF == 1: 
    M = b
    ToF=0
    print(M)
ToF += c>a and c>b and c>d
if ToF == 1: 
    M = c
    ToF=0
    print(M)
ToF += d>a and d>c and d>b # <- логическое выражение с and
if ToF == 1: # <- простое условие и короткое ветвление
    M = d
    ToF=0
    print(M)
print(M, ToF)

# Какая-то жесть получилась, но зато она соотвестует условиям:
# - Логические выражения с and/or есть
# - Простые условия без and/or есть
# - Короткие ветвления без else есть
# ToF - True or False