n = int(input())
print("{} подъезд {} этаж".format((n-1)//60+1, n//6%10+1))
