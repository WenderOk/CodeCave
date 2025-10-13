/*1*/
-- Только названий фильмов с The нету
select replace(title, "The ", "A") as title from film;
/*2*/
select left(description, 20) as description from film where title = "ACADEMY DINOSAUR";