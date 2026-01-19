DROP TABLE IF EXISTS Books;
DROP TABLE IF EXISTS Authors;

CREATE TABLE Authors(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(40),
    surname VARCHAR(40)
);
INSERT INTO Authors(name, surname)
VALUES ('Stephen', 'King'),
       ('Chuck', 'Palahniuk'),
       ('Jerome', 'Salinger'),
       ('Leo', 'Tolstoy');

CREATE TABLE Books(
    id           INT PRIMARY KEY AUTO_INCREMENT,
    title        VARCHAR(40),
    release_year INT,
    author_id    INT
);
INSERT INTO Books(title, release_year, author_id)
VALUES ('The Shining', 1977, 1),
       ('Fight Club', 1996, 2),
       ('The Catcher in the Rye', 1951, 3),
       ('The Green Mile', 1996, 1),
       ('Haunted', 2005, 2),
       ('The Outsider', 2018, 1),
       ('Lullaby', 2002, 2),
       ('Franny and Zooey', 1961, 3),
       ('Invisible Monsters', 1999, 2),
       ('Dolores Claiborne', 1993, 1);


create view BooksInfo (bookname, writer) as
select title, concat(Authors.name, " ", Authors.surname)
from Books inner join Authors on Books.author_id = Authors.id;

select * from BooksInfo;