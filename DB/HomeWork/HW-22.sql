/* 1 */
select followee as user, count(*) as followers from Follow where followee in (
select distinct followee from Follow where followee in (
select distinct follower from Follow)
) group by followee order by user asC;

/* 2 */
select id, sum(quantity) as total_quantity, count(distinct product_id) as distinct_products from Orders group by id 
having max(quantity) > ALL (
select sum(quantity) * 1.0 / count(distinct product_id) from Orders group by id
) order by id;

/* 3 */
select id from Candidates where years_of_exp >= 2 and interview_id in (
select interview_id from Rounds group by interview_id having sum(score) > 15
);

/* 4 */
select player_name, team, day, score_points,
(select sum(score_points) from Scores where team = Scores.team and day <= Scores.day
) as total
from Scores order by team, day;

/* 5 */
select first_name, last_name from customer where address_id in (
select address_id from address where city_id in (
select city_id from city where city = 'London'
));

/* 6 */
select title from Films as F1 where running_time > (
select running_time from Films as F2 where F2.show_date = date_sub(F1.show_date, interval 1 day)
) order by title;
