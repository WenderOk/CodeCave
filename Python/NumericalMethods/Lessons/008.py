import tkinter
import math
from time import time

width = 1920
height = 1080

root = tkinter.Tk()
canvas = tkinter.Canvas(root, width=width, height=height)
canvas.pack()

N = 10
x, y = [[0]*N, [0]*N]
velocity = [[0]*N, [0]*N]
EX, EY = 50, 50
for i in range(N):
    x[i] = EX + (width/2 - EX) / (N - 1) * i
    y[i] = EY - EY / (N - 1) * i
    velocity[0][i] = 100
    velocity[0][i] = 60
gravity = 200 # гравитационное ускорение
L0 = 0.5 * math.sqrt((width/2 - EX)**2 + EY**2) / (N - 1) # начальная длина пружины
K = 1.2 # константа Гука
M = 0.2 / N # масса пружинки
A = 0.0025 # сопротивление воздуха

def animate(time_old, x, y, r, velocity, gravity, width, height, K=1.2, M=0.2/2, A=0.0025, ball=None, L0=50):
    
    time_now = time()
    dt = time_now - time_old
    new_x, new_y = [0]*N, [0]*N
    for i in range(N - 1):
        phi = math.atan2(y[i+1] - y[i], x[i+1] - x[i])
        L = math.hypot(x[i+1] - x[i], y[i+1] - y[i])
        FH = K * (L - L0)
        Fx = FH * math.cos(phi) - A * velocity[0][i]
        Fy = M * gravity + FH  * math.sin(phi) - A * velocity[1][i]
        if i > 0:
            phi2 = math.atan2(y[i-1] - y[i], x[i-1] - x[i])
            L2 = math.hypot(x[i-1] - x[i], y[i-1] - y[i])
            PH2 = K * (L2 - L0)
            Fx += PH2 * math.cos(phi2)
            Fx += PH2 * math.sin(phi2)
        ax = Fx / M; ay = Fy / M
        velocity[0][i] += ax * dt; velocity[1][i] += ay * dt
        new_x[i] = x[i] +  velocity[0][i] * dt
        new_y[i] = y[i] +  velocity[1][i] * dt

        canvas.delete('all')
    for i in range(N - 2, -1, -1):
        x[i] = new_x[i]; y[i] = new_y[i]
        spring = canvas.create_line(x[i], y[i], x[i+1], y[i+1], fill='red')
    ball = canvas.create_oval(x[0] - r, y[0] - r, x[0] + r, y[0] + r, fill='red', outline='yellow')
    canvas.after(50, animate, time_now, x, y, r, velocity, gravity, width, height)
animate(time(), x, y, 25, velocity, 200 * 0.2/2, 1280, 720)
root.mainloop()