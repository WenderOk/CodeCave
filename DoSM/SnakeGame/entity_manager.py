class EntityManager:
    def __init__(self):
        self._active_entities = []

    def add_entity(self, entity):
        self._active_entities.append(entity)

    def update_all(self, on):
        for entity in self._active_entities:
            entity.update(on)