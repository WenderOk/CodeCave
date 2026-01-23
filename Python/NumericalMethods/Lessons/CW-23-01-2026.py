from random import choice
from random import randint
import tkinter

side = int(input("Enter side: "))

root = tkinter.Tk()
canvas = tkinter.Canvas(root, width=side, height=side)
canvas.pack()
for _ in range(25000):
    RGB = randint(0,255), randint(0,255), randint(0,255)
    color = "#{:02x}{:02x}{:02x}".format(*RGB)
    x = randint(0, side)
    y = randint(0,side)
    canvas.create_rectangle(
        x,y, x+1, y+1, fill= color, outline =color
)
root.mainloop()