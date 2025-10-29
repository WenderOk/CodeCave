# Объектно ориентированное программирование
import os
import random
import time
from enum import Enum
from dataclasses import dataclass


def get_current_term_size():
    size = os.get_terminal_size()
    width, height = int(size.columns), int(size.lines)
    return width - 2, height - 2


class Char(str, Enum):
    EMPTY = ' '
    FILLED = '#'


@dataclass
class Position:
    x: int
    y: int


@dataclass
class Pixel:
    pos: Position
    char: Char


class Frame:
    _width: int
    _height: int

    def __init__(self, width, height):  # магический, dunder (double under)
        self._width = width
        self._height = height

        self.matrix = [
            [
                Char.EMPTY.value for _ in range(self._width)
            ]
            for _ in range(self._height)
        ]

    def draw(self, pixel: Pixel):
        self.matrix[pixel.pos.y][pixel.pos.x] = pixel.char

    def render(self):
        result = ''
        for line in self.matrix:
            chars = ''.join(line)
            result += chars + '\n'
        print(result)


def main():
    FPS = 120

    width, height = get_current_term_size()

    x_start = 0
    y_start = 0

    xs = list(range(0, width)) + [width - 1, ] * height + list(range(width - 1, -1, -1)) + [0, ] * height
    ys = [0, ] * width + list(range(0, height)) + [height - 1, ] * width + list(range(height - 1, -1, -1))

    positions = [Pixel(Position(x, y), Char.FILLED) for x, y in zip(xs, ys)]
    frame_index = 0

    while True:
        frame = Frame(width, height)

        dot = positions[frame_index % len(positions)]

        frame.draw(dot)

        frame.render()


        frame_index += 1
        time.sleep(1 / FPS)


if __name__ == '__main__':
    print('start!')
    # pos = Position(1, 2)
    # print(pos.x + pos.y)

    main()
