/*Группировка данных*/
/*1*/
select store_id, count(*) as film_count from inventory group by store_id;
/*2*/
select rating, count(*) as film_count from film group by rating order by film_count desc;
/*3*/
select customer_id, sum(amount) as total_rent from payment group by customer_id order by customer_id;
/*4*/
select count(rental_id) as rental_count, month(rental_date) as month from rental group by month;
/*5*/
select rating, count(*) as film_count from film group by rating having film_count > 200 order by film_count desc;
/*6*/
select customer_id, sum(amount) as total_rent from payment group by customer_id having total_rent > 150 order by customer_id;

/*Вложенные запросы*/
select first_name, last_name from customer where address_id in
(select address_id from address where city_id in 
(select city_id from city where city = "London"));