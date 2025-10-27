DROP TABLE IF EXISTS Books;
CREATE TABLE Books(
    id        INT PRIMARY KEY AUTO_INCREMENT,
    title     VARCHAR(40),
    author    VARCHAR(40),
    price     DECIMAL(10, 2),
    quantity  INT
);

INSERT INTO Books (title, author, price, quantity)
VALUES ('Fight Club', 'Chuck Palahniuk', 9.99, 12),
       ('The Catcher in the Rye', 'J.D. Salinger', 3.49, 1),
       ('The Green Mile', 'Stephen King', 15.99, 4),
       ('The Great Gatsby', 'F. Scott Fitzgerald', 7.99, 3),
       ('The Lord of the Rings', 'J.R.R. Tolkien', 29.99, 0),
       ('The Shining', 'Stephen King', 7.99, 2),
       ('It', 'Stephen King', 12.99, 1),
       ('The Silmarillion', 'J.R.R. Tolkien', 11.99, 4),
       ('Haunted', 'Chuck Palahniuk', 13.99, 3),
       ('Harry Potter and the Prisoner of Azkaban', 'J.K. Rowling', 9.99, 100);