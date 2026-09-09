def digitSum(n):
    if n < 10:
        return n
    return digitSum(n // 10) + n % 10

print(digitSum(1234))