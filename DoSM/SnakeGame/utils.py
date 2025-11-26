from SnakeGame.events import EventType

def parse_tk_event(tk_event) -> EventType:
    return EventType(tk_event.lower())