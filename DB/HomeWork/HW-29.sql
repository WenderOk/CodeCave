/* 1 */
create table Students(
	id int primary key not null unique,
	name varchar(20) not null check (name != ""),
	surname varchar(20) not null check (surname != ""),
	age int default 18 check (age >= 18),
	date_of_receipt date default curdate() check (date_of_receipt >= "2023-09-01"),
	phone_number varchar(20) check (phone_number REGEXP '^[78] \\([0-9]{3}\\) [0-9]{3}-[0-9]{2}-[0-9]{2}$')
);

/* 2 */
select u.id, count(o.id) as purchases_in_2023 
from Users as u left join Orders as o 
on u.id = o.buyer_id and year(o.order_date) = "2023" 
group by u.id;

/* 3 */
select sum(b.apple_count + ifnull(s.apple_count, 0)) as total_apples, 
sum(b.orange_count + ifnull(s.orange_count, 0)) as total_oranges
from BigBoxes as b left join SmallBoxes as s on b.small_box_id = s.id;

/* 4 */
select p1.id as p1, p2.id as p2, abs(p1.x - p2.x) * abs(p1.y - p2.y) as area
from Points as p1 inner join Points as p2 on p1.id < p2.id
where p1.x != p2.x and p1.y != p2.y
order by area desc, p1, p2;