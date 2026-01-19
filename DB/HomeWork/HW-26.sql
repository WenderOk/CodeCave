/*1*/
create table Teams(
	id int primary key auto_increment,
	name varchar(50)
)

insert into Teams(name)
values 	("Manchester United"),
		("Liverpool FC"),
		("Chelsea FC"),
		("Arsenal FC"),
		("Manchester City"),
		("Tottenham Hotspur"),
		("Everton FC"),
		("Leicester City"),
		("West Ham United"),
		("Aston Villa FC");

select t1.name as home_team, t2.name as away_team
from Teams as t1
inner join Teams t2
on t1.name != t2.name;

/*2*/
DROP TABLE IF EXISTS Elements;
CREATE TABLE Elements(
    symbol VARCHAR(2),
    type   VARCHAR(10)
);

INSERT INTO Elements(symbol, type)
VALUES ('H', 'nonmetal'),
       ('Li', 'metal'),
       ('Be', 'metal'),
       ('C', 'nonmetal'),
       ('Ne', 'noble'),
       ('F', 'nonmetal'),
       ('Na', 'metal'),
       ('Mg', 'metal'),
       ('O', 'nonmetal'),
       ('N', 'nonmetal'),
       ('Al', 'metal'),
       ('P', 'nonmetal'),
       ('Ar', 'noble'),
       ('K', 'metal'),
       ('S', 'nonmetal'),
       ('Ca', 'metal'),
       ('Cl', 'nonmetal'),
       ('Kr', 'noble'),
       ('Rb', 'metal'),
       ('Br', 'nonmetal');

select m1.symbol as metal, m2.symbol as nonmetal
from Elements as m1
inner join Elements m2
on m1.type = "metal" and m2.type = "nonmetal";

/*3*/
select category.name as Category, avg(rental_duration) as avg_rental_dur
from film
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
group by category.name
order by avg_rental_dur desc;