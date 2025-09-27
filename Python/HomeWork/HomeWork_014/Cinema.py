'''
n,m,s = int(input()), int(input()), ""
if abs(n - m) > 1 and not(n * 2 == m or m * 2 == n): print("NO SOLUTION")
if n >= m:
    s+="B"
else: 
    s+="G"
for i in range(max(n,m)):
    if i < n  and (s[i-1] != "B" or s[i] != "B") and i+1<m:
        print(i) 
        s+="B"
        print("add B")
    elif i < m and s[i-1] != "G" or s[i] != "G" and i+1<m: 
        print(i) 
        s+="G"
        print("add G")
print(s)

n,m,s = int(input()), int(input()), ""
if n >= m:
    s+="B"
    for i in range(n+m-1):
        if m*2==n and s[i]=="G":
            s+="BB"
            s+="G"
            i+=3
        elif s[i]=="G": s+="B"
        else: s+="G"
else:
    s+="G"
    for j in range(n+m-1):
        if n*2==m and s[j] == "B":
            s+="GG"
            s+="B"
            j+=2    
        elif j < n: s+="G"
print(s)
'''
#Решил оставить попытки решения здесь для красоты)
 
n, m, s =  int(input("Введите количество мальчиков: ")), int(input("Введите количество девочек: ")), " "  
 
for i in range(1,n + m+1):   
    if n > m: 
        if i == 1: s += " " 
        if (s[i-1] != "B" and s[i-1] != " ") or s[i] != "B": s += "B" 
        else: s += "G" 
        
    elif m > n: 
        if i == 1: s += " "     
        if (s[i-1] != "G" and s[i-1] != " ") or s[i] != "G": s += "G" 
        else: s += "B"
            
    else:
        if s[i-1] == "G": s += "B" 
        else: s += "G"   
 
if s.count("B") == n and s.count("G") == m: 
    print(s.replace(" ", "")) 
else: 
    print("NO SOLUTION") 
