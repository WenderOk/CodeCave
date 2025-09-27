import heapq
import matplotlib.pyplot as plt
import networkx as nx

def dijkstra(graph, start):
    # Инициализация словаря для хранения расстояний
    # до каждой вершины. Сначала все расстояния бесконечны.
    distances = {vertex: float('infinity') for vertex in graph}
   
    # Расстояние до начальной вершины равно 0.
    distances[start] = 0
   
    # Создаём приоритетную очередь для хранения вершин и их расстояний.
    priority_queue = [(0, start)]

    while priority_queue:
            # Извлекаем вершину с наименьшим расстоянием из очереди.
            current_distance, current_vertex = heapq.heappop(priority_queue)
        
            # Если текущее расстояние до вершины уже больше, чем сохранённое расстояние, игнорируем её.
            if current_distance > distances[current_vertex]:
                continue
        
            # Рассмотрим все соседние вершины текущей вершины.
            for neighbor, weight in graph[current_vertex].items():
                distance = current_distance + weight
            
                # Если найден более короткий путь до соседа, обновим расстояние.
                if distance < distances[neighbor]:
                    distances[neighbor] = distance
                    heapq.heappush(priority_queue, (distance, neighbor))
    
    return distances

graph = {
    'A': {'B': 7, 'E': 4},
    'B': {'A': 7, 'F': 2, 'C': 5},
    'C': {'A': 5, 'D': 11, 'F': 6},
    'D': {'C': 11, 'E': 8, 'F': 9},
    'E': {'A': 4, 'D': 8, 'F': 3},
    'F': {'B': 2, 'C': 6, "D": 9, 'E': 3}
}

result = dijkstra(graph, 'A')
# Выводим результат.
print("Кратчайшие расстояния до каждой вершины:")
for vertex, distance in result.items():
    print(f"До вершины {vertex}: {distance}")


newdict = dict() 
for k, v in graph.items(): 
    newdict1 = dict() 
    for k1, v1 in v.items(): 
        newdict1[k1] = {'weight': v1} 
    newdict[k] = newdict1 
 
# вывести графическое представление графа 
 
G = nx.Graph(newdict) 
 
labels = {vertex: f'{vertex}:{distance}' for vertex, distance in result.items()} 
pos = nx.spring_layout(G, seed = 1) 
nx.draw(G, pos, with_labels = True, node_color = '#32CD32', 
        node_size = 1000, alpha = 0.9, labels = labels) 
 
edge_labels = nx.get_edge_attributes(G, "weight") 
nx.draw_networkx_edge_labels(G, pos, edge_labels) 
 
plt.show() 