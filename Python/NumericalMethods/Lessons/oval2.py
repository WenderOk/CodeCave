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
CX, CY, RX, RY = W/2, H/4, W/4, W/4 # начальные параметры пузыря
for i in range(N):
    phi = 2 * math.pi / N * i
    x[i] = CX + RX * math.cos(phi)
    y[i] = CY + RY * math.sin(phi)
gravity = 100 # 200 гравитационное ускорение
L0 = 0.5 * 2 * math.pi * (RX + RY) / 2 / N # начальная длина пружины
K = 0.02 # константа Гука
M = 0.2 / N # масса пружинки
A = 0.01 # сопротивление воздуха

def GaussShoelace(x, y):
    S = 0
    for i in range(len(x)):
        S += x[i - 1] * y[i] - x[i] * y[i - 1]
    return S

def GetNormalVector(p1, p2):
    mx = math.sin(p1) - math.sin(p2)
    my = -math.cos(p1) + math.cos(p2)
    n = math.sqrt(mx**2 + my**2)
    mx /= n
    my *= n
    return (nx, ny)

def animate(time_old, x, y, gravity, velocity):
  time_now = time(); dt = time_now - time_old
  new_x, new_y = [0] * N, [0] * N
  canvas.delete("all")
  for i in range(N): # у каждой пружины 2 соседа
      phi1 = math.atan2(y[(i+1) % N] - y[i], x[(i+1) % N] - x[i])
      L1 = math.hypot(x[(i+1) % N] - x[i], y[(i+1) % N] - y[i])
      FH1 = K * (L1 - L0)**2 # закон Гука
      phi2 = math.atan2(y[i-1] - y[i], x[i-1] - x[i])
      L2 = math.hypot(x[i-1] - x[i], y[i-1] - y[i])
      FH2 = K * (L2 - L0)**2 # закон Гука
      Fx = FH1 * math.cos(phi1) + FH2 * math.cos(phi2) - A * velocity[0][i]
      Fy = M * gravity + FH1 * math.sin(phi1) + FH2 * math.sin(phi2) - A * velocity[1][i]
      ax = Fx / M; ay = Fy / M # закон Ньютона 
      velocity[0][i] += ax * dt; velocity[1][i] += ay * dt
      new_x[i] = x[i] + velocity[0][i] * dt
      new_y[i] = y[i] + velocity[1][i] * dt

  for i in range(N):
      x[i] = new_x[i]; y[i] = new_y[i]
      canvas.create_line(x[i], y[i], x[i-1], y[i-1], fill='red', width=5)
  canvas.after(50, animate, time_now, x, y, gravity, velocity)

animate(time(), x, y, gravity, velocity)
root.mainloop()