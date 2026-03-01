import tkinter as tk

from dataclasses import dataclass
from SnakeGame.game_render import Position, Vector

from enum import Enum


SPEED = 100


class EventType(Enum):
    UP = 'up'
    DOWN = 'down'
    LEFT = 'left'
    RIGHT = 'right'


class Event:
    """Базовое событие игры."""

    def __init__(self, event_type: EventType, data: None):
        self._event_type = event_type
        self._data = data


class EventManager:
    """Класс, распределяющий игровые событие сущностям."""

    def __init__(self):
        self._listeners = {}

    def add_listener(self, event_type: EventType, listener: callable):
        listeners = self._listeners.get(event_type, [])
        listeners.append(listener)
        self._listeners[event_type] = listeners

    def dispatch(self, event):
        print(event)
        prepared_event = parse_tk_event(event)
        print(prepared_event)
        for listener in self._listeners.get(prepared_event, []):
            listener(prepared_event)


def parse_tk_event(tk_event) -> EventType:
    keysym = tk_event.keysym.lower()
    if keysym in EventType:
        return EventType(keysym)


class EntityManager:
    """
    Класс для отслеживания и управления сущностями в игре.
    """
    def __init__(self):
        self._active_entities = []

    def add_entity(self, entity):
        self._active_entities.append(entity)

    def update_all(self, on):
        for entity in self._active_entities:
            entity.update(on)
            
            


class Entity:
    """
    Базовая сущность для игровых объектов.
    """
    def update(self, on):
        """Обновление состояния объекта."""
        pass




@dataclass
class Config:
    window_width: int = 1280
    window_height: int = 720


class Snake(Entity):
    def __init__(self, start_position: Position, config: Config):
        self._position = start_position
        self._size = config.window_height // 10
        self._color = "white"

    def update(self, on):
        self.move()
        self.draw(on=on)

    def draw(self, on: tk.Canvas):
        offset_x = self._size / 2
        offset_y = self._size / 2
        on.create_rectangle(
            self._position.x - offset_x, self._position.y - offset_y,
            self._position.x + self._size - offset_x, self._position.y + self._size - offset_y,
            fill=self._color
        )

    def move(self):
        direction = Vector(1, 1)
        self._position += direction


def actions(window, entity_manager: EntityManager, canvas: tk.Canvas):
    canvas.delete("all")
    entity_manager.update_all(canvas)
    window.after(SPEED, actions, window, entity_manager, canvas)


import tkinter as tk

from dataclasses import dataclass
from lesson6.oop_basics import Position, Vector
from snake_game.entity_manager import EntityManager
from snake_game.events import EventManager, EventType
from snake_game.game_objects import Entity

SPEED = 100


@dataclass
class Config:
    window_width: int = 1280
    window_height: int = 720
    event_manager = None


class Snake(Entity):
    def __init__(self, start_position: Position, config: Config):
        self._position = start_position
        self._size = config.window_height // 10
        self._color = "white"
        self.__velocity = Vector(0, 0)
        self.__speed = 10

        config.event_manager.add_listener(EventType.UP, self.change_direction)
        config.event_manager.add_listener(EventType.DOWN, self.change_direction)
        config.event_manager.add_listener(EventType.LEFT, self.change_direction)
        config.event_manager.add_listener(EventType.RIGHT, self.change_direction)

    def change_direction(self, event_type: EventType):
        vector_map = {
            event_type.UP: Vector(0, -1),
            event_type.DOWN: Vector(0, 1),
            event_type.LEFT: Vector(-1, 0),
            event_type.RIGHT: Vector(1, 0),
        }
        if event_type in vector_map:
            self.__velocity = vector_map[event_type]


    def update(self, on):
        self.move()
        self.draw(on=on)

    def draw(self, on: tk.Canvas):
        offset_x = self._size / 2
        offset_y = self._size / 2
        on.create_rectangle(
            self._position.x - offset_x, self._position.y - offset_y,
            self._position.x + self._size - offset_x, self._position.y + self._size - offset_y,
            fill=self._color
        )

    def move(self):
        self._position += self.__velocity * self.__speed


def actions(window, entity_manager: EntityManager, canvas: tk.Canvas):
    canvas.delete("all")
    entity_manager.update_all(canvas)
    window.after(SPEED, actions, window, entity_manager, canvas)


def main(config: Config):
    window = tk.Tk()

    entity_manager = EntityManager()

    config.event_manager = EventManager()
    window.bind("<Key>", config.event_manager.dispatch)

    canvas = tk.Canvas(
        window,
        width=config.window_width,
        height=config.window_height
    )

    snake = Snake(Position(config.window_width // 2, config.window_height // 2), config)
    entity_manager.add_entity(snake)

    actions(window, entity_manager, canvas)
    canvas.pack()
    window.mainloop()


if __name__ == '__main__':
    config_720p = Config()
    config_1080p = Config(window_height=1080, window_width=1920)
    main(config=config_720p)

