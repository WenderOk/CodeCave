DROP TABLE IF EXISTS BooksRental;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Books;
DROP TABLE IF EXISTS Authors;

CREATE TABLE Authors(
    id     INT PRIMARY KEY AUTO_INCREMENT,
    author VARCHAR(40)
);
INSERT INTO Authors(author)
VALUES ('Chuck Palahniuk'),
       ('Stephen King'),
       ('John Tolkien');

CREATE TABLE Books(
    id        INT PRIMARY KEY AUTO_INCREMENT,
    author_id INT,
    title     VARCHAR(40)
);
INSERT INTO Books(author_id, title)
VALUES (1, 'Fight Club'),
       (2, 'The Green Mile'),
       (3, 'The Lord of the Rings'),
       (2, 'It'),
       (1, 'Haunted');


CREATE TABLE Users(
    id   INT PRIMARY KEY AUTO_INCREMENT,
    user VARCHAR(30)
);
INSERT INTO Users(user)
VALUES ('Keanu Reeves'),
       ('Matthew McConaughey'),
       ('Thomas Hanks'),
       ('Bradd Pitt'),
       ('Liam Neeson');

CREATE TABLE BooksRental(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    book_id INT,
    user_id INT
);
INSERT INTO BooksRental(book_id, user_id)
VALUES (4, 1),
       (1, 3),
       (2, 3),
       (4, 4),
       (3, 1);

select title 