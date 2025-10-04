/*1*/
select title from film where title like "A%" or title like "% Man";
/*2*/
select first_name, last_name from actor where last_name like "%NN%";
/*3*/
select first_name, last_name from customer where first_name like "J%Y" and lenght(first_name) >= 5;
/*4*/
select staff_id, first_name, last_name, concat(first_name, " ", last_name) as "ФИО сотрудника" from staff;
/*5*/
select film_id, title, rental_rate, (rental_rate * 5) as total_rental_cost from film order by total_rental_cost desc;