from collections import Counter

with open("/home/wender/Projects/CodeCave/Python/Algorithms/Lessons/Collections/the-zen-of-python.txt", 'r') as F:
    counter = Counter()
    for line in F:
        letters = [char for char in line.lower() if char.isalpha()]
        counter.update(letters)

for letter, count in counter.most_common():
    print(letter, "#" * count)

