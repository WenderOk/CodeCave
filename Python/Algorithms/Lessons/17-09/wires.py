N, K = map(int, input().split())

len = [int(input()) for _ in range(N)]

l = 1
r = 0


while l <= r:
    mid = l + (r - l) // 2

    count = 0

    for ln in len:
        count += ln // mid

   