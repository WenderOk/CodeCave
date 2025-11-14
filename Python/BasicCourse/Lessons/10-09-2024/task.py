a,b,c = map(int, input().split())
print("Сумма = {} Произвеение = {} Среднее = {}".format(a+b+c,b*b*c,round((a+b+c)/3,2)))

#This solution sucks!
#        \/          
'''
a = int(input())
b = int(input())
c = int(input())
print("{} + {} + {} = {}".format(a,b,c,a+b+c))
print("{} * {} * {} = {}".format(a,b,c,a*b*c))
print("({} + {} + {})/3 = {}".format(a,b,c,(a+b+c)/3))

'''