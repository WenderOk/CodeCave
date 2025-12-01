drop table if exists Students;
create table Students(
	id int not null unique,
	name varchar(20) not null check (name != ""),
	surname varchar(20) not null check (surname != ""),
	age int check (age >= 18) default 18,
	date_of_receipt date check (date_of_receipt >= "2023-09-01") default (curdate()) );
select * from Students;

create table Students(
	id int primary key auto_increment,
	name varchar(20) check (name != ""),
	surname varchar(20) check (surname != "")
);

create table Classes(
	id int primary key auto_increment,
	name varchar(20) check (name != "")
);

create table Classes(
	id int primary key auto_increment,
	student_id int,
	class_id int,
	grade int check (grade between 1 and 5),
	
	foreign key (student_id) references Students (id) on update cascade on delete cascade,
	foreign key (class_id) references Classes (id) on update cascade on delete cascade
);

