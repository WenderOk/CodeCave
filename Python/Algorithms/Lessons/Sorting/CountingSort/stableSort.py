s = [('Alice', 20, 'A'), ('Bob', 22, 'B'), ('Charlie', 20, 'C')]

by_name = sorted(s, key=lambda x: x[0])

res = sorted(by_name, key=lambda x: x[1])

print(res)

# Тут демонстрируется характеристика "стабильности" сортировки (сохранения исходного порядка при сопадении значений)