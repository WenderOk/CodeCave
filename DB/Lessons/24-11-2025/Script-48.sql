DROP TABLE IF EXISTS Drinks;
DROP TABLE IF EXISTS Meals;

CREATE TABLE Meals(
  id    INT PRIMARY KEY AUTO_INCREMENT,
  name  VARCHAR(50),
  price INT
);
INSERT INTO Meals(name, price)
VALUES ('Omlet', 2),
       ('Waffles', 4),
       ('Pizza', 10),
       ('Cheeseburger', 5);

CREATE TABLE Drinks(
  id    INT PRIMARY KEY AUTO_INCREMENT,
  name  VARCHAR(50),
  price INT
);
INSERT INTO Drinks(name, price)
VALUES ('Orange Juice', 3),
       ('Green Tea', 2),
       ('Coffee', 2),
       ('Water', 0);

select concat(Meals.name, ", " ,Drinks.name) as combo,concat(Meals.price + Drinks.price, "$") as price
from Meals cross join Drinks order by Meals.price + Drinks.price, Meals.name, Drinks.name;