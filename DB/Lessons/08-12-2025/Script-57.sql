DROP TABLE IF EXISTS Students;
CREATE TABLE Students(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(50),
    surname VARCHAR(50),
    age     INT
);
INSERT INTO Students(name, surname, age)
VALUES ('Peter', 'Parker', 18),
       ('Gwen', 'Stacy', 21),
       ('Flash', 'Tompson', 19),
       ('Mary', 'Jane', 18),
       ('Eddie', 'Brock', 21);

DROP TABLE IF EXISTS Teachers;
CREATE TABLE IF NOT EXISTS Teachers(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(50),
    surname VARCHAR(50),
    subject VARCHAR(50)
);

INSERT INTO Teachers(name, surname, subject)
VALUES ('Norman', 'Osborn', 'algebra'),
       ('Curt', 'Connors', 'informatics'),
       ('Harry', 'Osborn', 'english'),
       ('Flint', 'Marko', 'chemistry'),
       ('Richard', 'Parker', 'physics');

alter table Students add column hometown varchar(20) 
	not null default "New York City"
	after surname;

alter table Students alter column name set default "";

alter table Students drop column id,
add primary key(name, surname);

alter table Students
	add check(char_lenght(name) >= 2),
	add check(char_lenght(surname) >= 2),
	add check(age > 0);

create table Students(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    fullname    VARCHAR(50)
);
INSERT INTO Students(fullname)
VALUES ('Peter Parker'),
       ('Gwen Stacy'),
       ('Flash Tompson'),
       ('Mary Jane'),
       ('Eddie Brock');

alter table Students 
add column name varchar(20),
add column surname varchar(20);

update Students
set name = SUBSTRING_INDEX(fullname, ' ', 1),
	surname = SUBSTRING_INDEX(fullname, ' ', -1);
alter table Students drop column fullname;

