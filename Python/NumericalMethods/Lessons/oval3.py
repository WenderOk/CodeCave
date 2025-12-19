from time import time
import tkinter
import math

root = tkinter.Tk()
W = 400
H = 800
canvas = tkinter.Canvas(root, width=W, height=H)
canvas.pack()


# параметры пузыря
N = 40 # число пружин
x, y = [0]*N, [0]*N
velocity = [[0]*N, [0]*N] # скорости
CX, CY, RX, RY = W/2, 3*H/8, W/8, W/4
for i in range(N):
    phi = 2 * math.pi / N * i
    rx = RX * (1 + 0.05 * math.cos(4 * phi))
    ry = RY * (1 + 0.05 * math.sin(5 * phi))
    x[i] = CX + rx * math.cos(phi)
    y[i] = CY + ry * math.sin(phi)
gravity = 3 # гравитационное ускорение
L0 = 0.5 * 2 * math.pi * (RX + RY) / 2 / N # начальная длина пружины
K = 0.04 # константа Гука
M = 2 / N # масса пружинки
A = 0.01 # сопротивление воздуха
BM = 100000 # константа Бойля-Мариотта

def getNormalVector(p1, p2):
    nx = math.sin(p1) - math.sin(p2)
    ny = -math.cos(p1) + math.cos(p2)
    n = math.sqrt(nx**2 + ny**2)
    nx /= n
    ny /= n
    return (nx, ny)
def GaussShoelace(x, y):
    S = 0
    for i in range(len(x)):
        S += x[i - 1] * y[i] - x[i] * y[i-1]
    return S


BM = 100000 # константа Бойля-Мариотта
def animate(time_old, x, y, gravity, velocity):
    time_now = time()
    dt = time_now - time_old
    new_x, new_y = [0] * N, [0] * N
    canvas.delete("all")
    S = GaussShoelace(x, y)
    P = BM / S # давление
    for i in range(N): # у каждой пружины 2 соседа
        phi1 = math.atan2(y[(i+1) % N] - y[i], x[(i+1) % N] - x[i])
        L1 = math.hypot(x[(i+1) % N] - x[i], y[(i+1) % N] - y[i])
        FH1 = K * (L1 - L0)**2 # закон Гука
        phi2 = math.atan2(y[i-1] - y[i], x[i-1] - x[i])
        L2 = math.hypot(x[i-1] - x[i], y[i-1] - y[i])
        FH2 = K * (L2 - L0)**2 # закон Гука
        nx, ny = getNormalVector(phi1, phi2)    

        Fx = FH1 * math.cos(phi1) + FH2 * math.cos(phi2) - A * velocity[0][i] + P * nx
        Fy = M * gravity + FH1 * math.sin(phi1) + FH2 * math.sin(phi2) - A * velocity[1][i] + P * ny
        ax = Fx / M; ay = Fy / M # закон Ньютона 
        velocity[0][i] += ax * dt; velocity[1][i] += ay * dt
        new_x[i] = x[i] + velocity[0][i] * dt
        new_y[i] = y[i] + velocity[1][i] * dt
        # canvas.create_line(x[i], y[i], x[i] + 10 * A * velocity[0][i], y[i] + 10 * A * velocity[1][i], fill='red', width=5)
    canvas.create_polygon(*zip(x,y), fill="lightgreen")
    for i in range(N):
        x[i] = new_x[i]; y[i] = new_y[i]
    canvas.after(50, animate, time_now, x, y, gravity, velocity)

animate(time(), x, y, gravity, velocity)
root.mainloop()