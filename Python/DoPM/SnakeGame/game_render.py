# Объектно ориентированное программирование
import os
import random
import time
from enum import Enum
from dataclasses import dataclass


def get_current_term_size():
    size = os.get_terminal_size()
    width, height = int(size.columns), int(size.lines)
    return width, height - 2


class Char(str, Enum):
    EMPTY = ' '
    FILLED = '@'


@dataclass
class Position:
    x: int
    y: int

    def __add__(self, other): # + other
        return Position(self.x + other.x, self.y + other.y)

    def __sub__(self, other): # - other
        return Position(self.x - other.x, self.y - other.y)


@dataclass
class Vector:
    x: int
    y: int

    def __mul__(self, other: int): # * other
        return Vector(self.x * other, self.y * other)


@dataclass
class Pixel:
    pos: Position
    char: Char
    velocity: Vector

    def move(self):
        self.pos += self.velocity

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
    FPS = 10
    frame_index = 0

    dots = []


    while True:
        width, height = get_current_term_size()
        frame = Frame(width, height)

        dots.append(Pixel(Position(0, 0), Char.FILLED, Vector(1, 1) * 5))

        for dot in dots[::-1]:
            frame.draw(dot)
            frame.render()

            dot.move()

            if dot.pos.x < 0:
                dot.pos.x = width - 1 + dot.pos.x
            elif dot.pos.x >= width:
                dot.pos.x = 0

            if dot.pos.y < 0:
                dot.pos.y = height - 1 + dot.pos.y
            elif dot.pos.y >= height:
                dot.pos.y = 0
        frame_index += 1
        time.sleep(1 / FPS)


def calc_perim_positions(height, width):
    xs = list(range(0, width)) + [width - 1, ] * height + list(range(width - 1, -1, -1)) + [0, ] * height
    ys = [0, ] * width + list(range(0, height)) + [height - 1, ] * width + list(range(height - 1, -1, -1))
    positions = [Pixel(Position(x, y), Char.FILLED) for x, y in zip(xs, ys)]
    return positions


if __name__ == '__main__':
    print('start!')
    # pos = Position(1, 2)
    # print(pos.x + pos.y)

    main()
