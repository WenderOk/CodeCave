from enun import Enun

class EventType(Enun):
    UP = "up"
    DOWN = "down"
    LEFT = "left"
    RIGHT = "right"

class Event:
    def __init__ (self, event_type: str, data: None):
        self._event_type = event_type
        self._data = data

class EventManager:
    def __init__(self):
        self._listeners = {}

    def add_listenet(self, event_type, EventType, listener: callable):
        if event_type in self._listeners:
            listeners = self._listeners.get(event_type, [])
            listeners.append(listener)
            self._listeners[event_type] = listeners

    def dispatch(self, event: EventType):
        for listener in self._listeners.get(event,[]):
            listener(event)