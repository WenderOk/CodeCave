import numpy as np
import matplotlib.pyplot as plt
from scipy.spatial.distance import pdist, squareform
from scipy.cluster.hierarchy import fcluster, linkage
from sklearn.cluster import DBSCAN

# Да, с Темой сговорился и мы совместно делали. А еще у меня jupyther умер...

def read_points(file_name):
    points = []
    with open(file_name, 'r') as f:
        for line in f:
            if line.strip():
                x, y = map(lambda s: float(s.replace(',', '.')), line.strip().split())
                points.append([x, y])
    return np.array(points)

def find_center(cluster_points):
    min_sum_dist = float('inf')
    center = None
    
    for i, point1 in enumerate(cluster_points):
        dist_sum = 0
        for j, point2 in enumerate(cluster_points):
            if i != j:
                dist = np.sqrt((point1[0] - point2[0])**2 + (point1[1] - point2[1])**2)
                dist_sum += dist
        if dist_sum < min_sum_dist:
            min_sum_dist = dist_sum
            center = point1
    return center

def cluster_points_dbscan(points, eps=9, min_samples=1):
    clustering = DBSCAN(eps=eps, min_samples=min_samples).fit(points)
    labels = clustering.labels_
    
    unique_labels = set(labels)
    if -1 in unique_labels:
        unique_labels.remove(-1)
    
    clusters = []
    for label in unique_labels:
        cluster = points[labels == label]
        clusters.append(cluster)
    
    return clusters

def analyze_file(file_name, R=9, plot=False):
    points = read_points(file_name)
    print(f"\nFile {file_name}: total points {len(points)}")
    
    clusters = cluster_points_dbscan(points, eps=R)
    
    centers = []
    for i, cluster in enumerate(clusters):
        center = find_center(cluster)
        centers.append(center)
        print(f"{len(cluster)} points, center ({center[0]:.4f}, {center[1]:.4f})")
    
    centers = np.array(centers)
    Px = np.mean(centers[:, 0])
    Py = np.mean(centers[:, 1])
    
    print(f"Px = {Px:.6f}, Py = {Py:.6f}")
    print(f"Px*100 000 = {int(Px * 100000)}")
    print(f"Py*100 000 = {int(Py * 100000)}")
    
    if plot:
        plt.figure(figsize=(10, 10))
        plt.scatter(cluster[:, 0], cluster[:, 1], c="green")
        
        centers = np.array(centers)
        plt.scatter(centers[:, 0], centers[:, 1], c='red', marker='o', s=100, label='Center')
        
        plt.xlabel('X')
        plt.ylabel('Y')
        plt.title(file_name)
        plt.legend()
        plt.grid(True, alpha=0.5)
        plt.axis('equal')
        plt.show()
    
    return centers, Px, Py

centers_A, Px_A, Py_A = analyze_file("data/27_p1_a.txt", R=9, plot=True)
centers_B, Px_B, Py_B = analyze_file("data/27_p1_b.txt", R=9, plot=True)

print(f"\nFile A: {int(Px_A * 100000)} {int(Py_A * 100000)}")
print(f"File B: {int(Px_B * 100000)} {int(Py_B * 100000)}")