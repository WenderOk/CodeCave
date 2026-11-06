from collections import Counter

A = list(map(int, input().split()))
counter = Counter(A)

res = counter.most_common(1)[0][0]

print(res)
