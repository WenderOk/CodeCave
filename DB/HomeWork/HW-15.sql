/* 1 */
select concat(name, ' ', surname) as staffer,
sec_to_time(time_to_sec(timediff(work_end, work_start)) - time_to_sec(timediff(break_end, break_start))) as work_time 
from Staff order by work_time desc, staffer;

/* 2 */
select name, timediff(rent_end, rent_start) as rent_time,
concat(floor(time_to_sec(timediff(rent_end, rent_start)) / 3600) * 10, '€') as rent_amount
from Rental where car_brand = 'BMW' order by rent_time, name;

/* 3 */
select task, executor, timediff(task_end, task_start) + 1 as days_spent from Tasks order by days_spent desc limit 1;
