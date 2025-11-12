import tkinter as tk

from dataclasses import dataclass


@dataclass
class Vector:
    x: int
    y: int

    def __mul__(self, other: int): # * other
        return Vector(self.x * other, self.y * other)
    
@dataclass
class Position:
    x: int
    y: int

    def __add__(self, other): # + other
        return Position(self.x + other.x, self.y + other.y)

    def __sub__(self, other): # - other
        return Position(self.x - other.x, self.y - other.y)

@dataclass
class Config:
    window_width: int = 1280
    window_height: int = 720


class Snake:
    def __init__(self, start_position: Position, config: Config):
        self._position = start_position
        self._size = config.window_height // 10
        self._color = "white"

    def draw(self, on: tk.Canvas):
        offset_x = self._size / 2
        offset_y = self._size / 2
        on.create_rectangle(
            self._position.x - offset_x, self._position.y - offset_y,
            self._position.x + self._size - offset_x, self._position.y + self._size - offset_y,
            fill=self._color
        )

    def move(self):
        print('move')
        direction = Vector(1, 1)
        self._position += direction


def actions(snake: Snake, canvas: tk.Canvas):
    snake.move()
    snake.draw(on=canvas)


def main(config: Config):
    window = tk.Tk()

    canvas = tk.Canvas(
        window,
        width=config.window_width,
        height=config.window_height
    )

    snake = Snake(Position(config.window_width // 2, config.window_height // 2), config)
    
    actions(snake, canvas)
    
    canvas.pack()
    window.mainloop()
    window.after(1000, actions, snake, canvas)


if __name__ == '__main__':
    config_720p = Config()
    config_1080p = Config(window_height=1080, window_width=1920)
    main(config=config_720p)
