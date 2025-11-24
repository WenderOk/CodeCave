DROP TABLE IF EXISTS Sales;
DROP TABLE IF EXISTS Products;

CREATE TABLE Products(
    id    INT PRIMARY KEY AUTO_INCREMENT,
    name  VARCHAR(50),
    price INT
);
INSERT INTO Products(name, price)
VALUES ('Apple iPhone 13 Pro', 900),
       ('Samsung Galaxy S21', 600),
       ('Lenovo ThinkPad X1 Carbon', 1400),
       ('Dell XPS 13', 600),
       ('Canon EOS R6', 1900);

CREATE TABLE Sales(
    id         INT PRIMARY KEY AUTO_INCREMENT,
    product_id INT,
    sale_date  DATE
);
INSERT INTO Sales (product_id, sale_date)
VALUES (1, '2023-09-11'),
       (2, '2023-09-11'),
       (1, '2023-09-11'),
       (2, '2023-09-12'),
       (4, '2023-09-12'),
       (1, '2023-09-12'),
       (4, '2023-09-12'),
       (4, '2023-09-13'),
       (4, '2023-09-13'),
       (1, '2023-09-14');


select name from Products left join Sales on Sales.product_id = Products.id where product_id is null;

select name as product, 
coalesce(min(sale_date), "Not Sold") as first_sale 
from Products left join Sales on Sales.product_id = Products.id group by product;

select name as product, 
concat(ifnull(count(Sales.product_id) * price, 0), "$") as amount
from Products left join Sales on Sales.product_id = Products.id group by Products.id; 