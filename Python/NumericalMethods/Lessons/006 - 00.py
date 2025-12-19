import tkinter
from time import time

width = 1280
height = 720

root = tkinter.Tk()
canvas = tkinter.Canvas(root, width=width, height=height)
canvas.pack()

x, y = 50, 50 # координаты центров
velocity_x, velocity_y = 100, 8 # скорости
r = 25
mass = 40
gravity = 10 * mass

def animate(time_old, x, y, r, velocity_x, velocity_y, gravity, width, height, last_coords, ball=None):
    time_now = time()
    dt = time_now - time_old
    time_old = time_now
    velocity_y += gravity * dt
    x += velocity_x * dt
    y += velocity_y * dt
    if x < r or x > width - r:
        velocity_x *= -0.95
    if y < r or y > height - r:
        velocity_y *= -0.9
    velocity_x *= 0.99
    velocity_y *= 0.99

    if ball != None: canvas.delete(ball)
    for i in range(len(last_coords) - 1):
        canvas.create_line(last_coords[0], last_coords[1],
                           x, y, fill='green')
    ball = canvas.create_oval(x - r, y - r, x + r, y + r, fill='red', outline='yellow')
    canvas.after(50, animate, time_old, x, y, r, velocity_x, velocity_y, gravity, width, height, (x, y), ball)
animate(time(), 50, 50, 25, 100, 1, 10 * mass, 1280, 720, (x, y))
root.mainloop()