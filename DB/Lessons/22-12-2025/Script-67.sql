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


set @min_price := 7.99,	@max_price := 9.99;

select title, price from Books where price between @min_price and @max_price;

select min(price) into @min_price from Books;
select @min_price;

/* Системные переменные */
/* Некоторые read-only */
select @@version;

set @@global.sort_buffer_size := 262144;
set @@session.sort_buffer_size := 262146;
select @@global.sort_buffer_size, @@session.sort_buffer_size;

set @number := conv(2361822,10,2)
select @number;

set @name := "George", @birthdate := "2008-03-18", @pets := 1;
select @name, @birthdate, @pets;
