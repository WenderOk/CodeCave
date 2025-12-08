create table Users(
id int auto_increment,
name varchar(20),
surname varchar(20),
phone_number varchar(20),
primary key (id)
);

insert into Users(name, surname, phone_number)
values("asd","asdfg", "+7321654987"),
	  ("ohjl","vsndljkv", "+7546384324"),
	  ("dfgsd","liusdvbh", "+7658463513"),
	  ("werrt","ojhlj", "+7498641325"),
	  ("xcbcv","sdfsdf", "+7321654987");

delimiter //
create trigger phone_number_formatting
after update on Authors for each row
begin
	set new.phone_number = concat("+7",
	substring(replace(new.phone_number, " ", ""), 3);

end //
create trigger phone_number_formatting
before insert on Authors for each row
begin
	set new.phone_number = concat("+7",
	substring(replace(new.phone_number, " ", ""), 3);

end //
delimiter ;