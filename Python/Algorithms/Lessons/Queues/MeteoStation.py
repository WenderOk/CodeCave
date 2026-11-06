with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Queues/27_B.txt", "r") as F:
    K = int(F.readline())
    N = int(F.readline())

    queue = [int(F.readline()) for _ in range(K)]

    mxprev = mxsum = 0

    for i in range(N-K):
        n = int(F.readline())

        idx = i % K
        prev = queue[idx]

        if prev > mxprev:
            mxprev = prev
        if mxprev + n > mxsum:
            mxsum = mxprev + n

        queue[idx] = n

print(mxsum)
        
