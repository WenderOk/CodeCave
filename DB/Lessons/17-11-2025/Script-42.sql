-- DROP TABLE IF EXISTS Purchases;
-- DROP TABLE IF EXISTS Users;
-- DROP TABLE IF EXISTS Films;
-- 
-- CREATE TABLE Films(
--     id       INT PRIMARY KEY AUTO_INCREMENT,
--     title    VARCHAR(20),
--     director VARCHAR(20),
--     price    FLOAT
-- );
-- INSERT INTO Films (title, director, price)
-- VALUES ('Toy Story 2', 'John Lasseter', 2.99),
--        ('WALL-E', 'Andrew Stanton', 4.99),
--        ('Ratatouille', 'Brad Bird', 4.99),
--        ('Up', 'Pete Docter', 4.99),
--        ('Brave', 'Brenda Chapman', 7.99),
--        ('Monsters University', 'Dan Scanlon', 7.99),
--        ('Cars 2', 'John Lasseter', 7.99),
--        ('Finding Nemo', 'Andrew Stanton', 4.99),
--        ('Toy Story', 'John Lasseter', 2.99),
--        ('The Incredibles', 'Brad Bird', 4.99);
-- 
-- CREATE TABLE Users(
--     id      INT PRIMARY KEY AUTO_INCREMENT,
--     name    VARCHAR(40),
--     surname VARCHAR(40)
-- );
-- INSERT INTO Users (name, surname)
-- VALUES ('Matt', 'Damon'),
--        ('Edward', 'Norton'),
--        ('Nicolas', 'Cage'),
--        ('Ben', 'Affleck'),
--        ('John', 'Travolta');
-- 
-- CREATE TABLE Purchases(
--     id      INT PRIMARY KEY AUTO_INCREMENT,
--     film_id INT,
--     user_id INT
-- );
-- TRUNCATE Purchases;
-- INSERT INTO Purchases (film_id, user_id)
-- VALUES (1, 1),
--        (1, 3),
--        (2, 4),
--        (1, 2),
--        (9, 4),
--        (6, 1),
--        (7, 2),
--        (6, 3),
--        (5, 1),
--        (10, 1);


select distinct name, surname from Users where id not in (select distinct user_id from Purchases);

select title, director from Films where id in (select distinct film_id from Purchases) order by title;

select count(film_id) as num_of_users from Purchases where film_id = (select distinct id from films where title = "Toy Story 2");

select name, surname from Users where id in (select user_id from Purchases where film_id = (select distinct id from films where title = "Toy Story 2" limit 1));

select name, surname
from Users as Us 
where 2 = (select count(film_id)
from Purchases where user_id = Us.id);

select name, surname,(
select title from Films 
where id = (select film_id from purchases where user_id = us.id limit 1)) as first_film
from Users as us where id in (select distinct user_id from Purchases) order by name;

select name, surname, coalesce((
	select sum(price) from films 
	where id in 
	(select film_id from Purchases where user_id = us.id)
),0) as total_spending
from Users as us;








