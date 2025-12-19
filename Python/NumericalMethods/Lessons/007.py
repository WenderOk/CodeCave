import tkinter
import math
from time import time

width = 1920
height = 1080

root = tkinter.Tk()
canvas = tkinter.Canvas(root, width=width, height=height)
canvas.pack()

mass = 100

def animate(time_old, x, y, r, velocity_x, velocity_y, gravity, width, height, last_coords, K, M, A, ball=None, L0=50):
    time_now = time()
    dt = time_now - time_old
    phi = math.atan2(0 - y, width / 2 - x)
    L = math.sqrt((x - width / 2)**2 + y**2)
    FH = K * (L - L0)
    Fx = FH * math.cos(phi) - A * velocity_x
    Fy = M * gravity + FH  * math.sin(phi) - A * velocity_y
    ax = Fx / M; ay = Fy / M
    velocity_x += ax * dt; velocity_y += ay * dt
    x += velocity_x * dt; y += velocity_y * dt

    if ball != None:
        canvas.delete(ball)
        canvas.delete('all')
    #canvas.create_line(last_coords[0], last_coords[1], x, y, fill='green')
    spring = canvas.create_line(width/2, 0, x, y, fill='red')
    ball = canvas.create_oval(x - r, y - r, x + r, y + r, fill='red', outline='yellow')
    canvas.after(50, animate, time_now, x, y, r, velocity_x, velocity_y, gravity, width, height, (x, y), K, M, A, ball)
animate(time(), 50, 50, 25, 100, 100, 10 * mass, 1280, 720, (50, 50), 1.0, 1, 0.2)
root.mainloop()