def gcd(a, b):
    if a == 0 or b ==0:
        return a + b
    if a < b:
        a,b = b,a
    return gcd(a % b, b)

print(gcd(5, 15))
print(gcd(31,40))
print(gcd(100,25))
print(gcd(7,5))

# НОК = LCM, НОД = GCD
# LCM(a, b) = a*b / GCD(a,b)
# Асимптотическая сложность модифицировнного алгоритма Евклида
# O(log min(a, b))
# Асимптотическая сложность обычного алгоритма Евклида
# O(log max(a, b))