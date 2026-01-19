drop table if exists Authors;
create table Authors(
	id int primary key auto_increment,
	name varchar(40),
	surname varchar(40)
);
INSERT INTO Authors(name, surname)
VALUES ('Stephen', 'King'),
       ('Chuck', 'Palahniuk'),
       ('Jerome', 'Salinger');

delimiter //
create trigger name_and_surname_formatting
before insert on Authors for each row
begin
	set new.name = concat(upper(left(new.name, 1)),
	lower(Substring(new.name, 2)));
	set new.surname = concat(upper(left(new.surname, 1)),
	lower(Substring(new.surname, 2)));
end //
delimiter ;

drop table if exists AuthorsNameHistory;
create table AuthorsNameHistory(
	log_id int,
	author_id int,
	old_name varchar(40),
	old_surname varchar(40),
	new_name varchar(40),
	new_surname varchar(40)
);

delimiter //
create trigger name_and_surname_logging
after update on Authors for each row
begin
	insert into AuthorsNameHistory (author_id, old_name, old_surname, new_name, new_surname)
	values (old.id, old.name, old.surname, new.name, new.surname);
end //
delimiter ;