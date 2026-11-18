class HeavyObject:
    def __init__(self, value: int, delay_loops: int = 3000):
        self.value = value
        self.delay_loops = delay_loops

    def __lt__(self, other):
        if not isinstance(other, HeavyObject):
            return NotImplemented
        for _ in range(self.delay_loops):
            pass
        return self.value < other.value