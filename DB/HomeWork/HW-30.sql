/* 1 */
drop table if exists Users;
create table Users(
	id int primary key, /* Не знаю нужен ли тут auto_increment. Для таблицы UsersEmailHistory явно указано что надо... */
	name varchar(20),
	surname varchar(20),
	email varchar(40)
);

create table UsersEmailHistory(
	log_id int primary key auto_increment,
	user_id int,
	old_email varchar(40),
	new_email varchar(40),
	updated_on date default curdate()
);

delimiter //
create trigger log_user_email_change
after update on Users for each row
begin
	insert into UsersEmailHistory(user_id, old_email, new_email, updated_on)
	values(old.id, old.email, new.email, curdate());
end //
delimiter ;

/* 2 */
delimiter //
create trigger total_spending_after_purchase_update
after insert on Purchases for each row
begin
    declare film_price decimal(5, 2) = (select price from Films where id = new.film_id;);
    update Users set total_spending = total_spending + film_price
    where id = new.user_id;
end //
delimiter ;