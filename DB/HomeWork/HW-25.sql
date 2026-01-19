/*1*/
select u.name, u.surname, f.title as most_expensive_film
from Users u
join Purchases p on u.id = p.user_id
join Films f on p.film_id = f.id
where f.price = (
    select max(f2.price) from Purchases p2
    join Films f2 on p2.film_id = f2.id where p2.user_id = u.id
)
and f.title = (
    select min(f3.title) from Purchases p3
    join Films f3 on p3.film_id = f3.id
    where p3.user_id = u.id AND f3.price = f.price
)
order by f.price desc, f.title, u.name;

/*2*/
select c.name as category_name, count(fc.film_id) as film_count
from category c
left join film_category fc on c.category_id = fc.category_id
group by c.category_id, c.name
order by film_count desc;

/*3*/
select c.first_name, c.last_name, sum(p.amount) as TotalPayments
from customer c
join payment p on c.customer_id = p.customer_id
group by c.customer_id, c.first_name, c.last_name
order by TotalPayments desc limit 5;

/*4*/
select st.first_name, st.last_name, s.store_id, sum(p.amount) as StoreRevenue
from staff st
join store s on st.store_id = s.store_id
join payment p on st.staff_id = p.staff_id
group by st.staff_id, st.first_name, st.last_name, s.store_id
order by s.store_id, StoreRevenue;

/*5*/
select a.first_name, a.last_name, count(r.rental_id) as rental_count
from actor a
join film_actor fa on a.actor_id = fa.actor_id
join film f on fa.film_id = f.film_id
join inventory i on f.film_id = i.film_id
join rental r on i.inventory_id = r.inventory_id
group by a.actor_id, a.first_name, a.last_name
order by rental_count desc limit 5;

/*6*/
select s.id as sale_id,s.sale_date, p.name as product, c.name as category
from Sales s
join Products p on s.product_id = p.id
join Categories c on p.category_id = c.id order by s.id;

/*7*/
select c.name as category, sum(p.price) as total_sales
from Categories c
join Products p on c.id = p.category_id
join Sales s on p.id = s.product_id
group by c.id, c.name order by total_sales desc limit 1;
