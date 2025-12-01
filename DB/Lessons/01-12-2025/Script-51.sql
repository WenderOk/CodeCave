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


select id, name, surname from Students
union
select id, name, surname from Teachers;