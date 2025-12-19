from time import time
import tkinter
import math

root = tkinter.Tk()
W = 400
H = 800
canvas = tkinter.Canvas(root, width=W, height=H)
canvas.pack()

N = 20 # число пружин
x, y = [0]*N, [0]*N
velocity = [[0]*N, [0]*N] # скорости
EX, EY = 50, 50 # конец верёвки
for i in range(N):
    x[i] = EX + (W / 2 - EX) / (N - 1) * i
    y[i] = EY - EY / (N - 1) * i
    velocity[0][i] = 100 # - 100 / (N - 1) * i
    velocity[1][i] = 60 # - 60 / (N - 1) * i
gravity = 200 # гравитационное ускорение
L0 = 0.5 * math.sqrt((W/2 - EX)**2 + EY**2) / (N - 1) # начальная длина пружины
K = 1.2 # константа Гука
M = 0.2 / N # масса пружинки
A = 0.0025 # сопротивление воздуха
def animate(time_old, x, y, r, gravity, velocity):
  time_now = time()
  dt = time_now - time_old
  new_x, new_y = [0] * N, [0] * N
  for i in range(N - 1): # последнюю пружину с шариком не двигаем
     phi = math.atan2(y[i+1] - y[i], x[i+1] - x[i]) # угол от координат пружины
     L = math.hypot(x[i+1] - x[i], y[i+1] - y[i])
     FH = K * (L - L0) # закон Гука
     Fx = FH * math.cos(phi) - A * velocity[0][i] # проекция на 0x + сопротивление воздуха
     Fy = M * gravity + FH * math.sin(phi) - A * velocity[1][i] # на 0y
     if i > 0: # не потолок
         phi2 = math.atan2(y[i-1] - y[i], x[i-1] - x[i])
         L2 = math.hypot(x[i-1] - x[i], y[i-1] - y[i])
         FH2 = K * (L2 - L0) # закон Гука
         Fx += FH2 * math.cos(phi2)
         Fy += FH2 * math.sin(phi2)
     ax = Fx / M; ay = Fy / M # закон Ньютона 
     velocity[0][i] += ax * dt; velocity[1][i] += ay * dt
     new_x[i] = x[i] + velocity[0][i] * dt
     new_y[i] = y[i] + velocity[1][i] * dt
     canvas.delete("all")
  for i in range(N - 2, -1, -1):
     x[i] = new_x[i]; y[i] = new_y[i]
     canvas.create_line(x[i], y[i], x[i+1], y[i+1], fill='red', width=5)
  canvas.create_oval(x[0] - r, y[0] - r, x[0] + r, y[0] + r, fill='red', outline='yellow')
  canvas.after(50, animate, time_now, x, y, r, gravity, velocity)
animate(time(), x, y, 10, 100, velocity)
root.mainloop()