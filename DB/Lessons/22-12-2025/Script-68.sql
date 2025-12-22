DROP TABLE IF EXISTS Directors;
CREATE TABLE Directors(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(40),
    surname VARCHAR(40),
    country VARCHAR(40),
    email VARCHAR(40),
    rating  INT
);

--TRUNCATE Directors;
INSERT INTO Directors (name, surname, country, email, rating)
VALUES ('Christopher', 'Nolan', 'England', 'chris@gmail.com', 90),
       ('Steven', 'Spielberg', 'USA', 'sspil@outlook.com', 79),
       ('Quentin', 'Tarantino', 'USA', 'queen@gmail.com', 95),
       ('Martin', 'Scorsese', 'USA', 'martins@outlook.com', 68),
       ('David', 'Fincher', 'USA', 'dfincher@outlook.com', 100),
       ('Ridley', 'Scott', 'England', 'riddler@gmail.com', 54),
       ('Stanley', 'Kubrick', 'USA', 'bigstan@icloud.com', 9),
       ('Clint', 'Eastwood', 'USA', 'cowboy@yahoo.com', 74),
       ('James', 'Cameron', 'Canada', 'jamesava@yahoo.com', 8),
       ('Tim', 'Burton', 'USA', 'timmy@icloud.com', 41),
       ('Quentin', 'Jerome', 'France', 'jerome@icloud.com', 80),
       ('Akiro', 'Kurosawa', 'Japan', 'akiro.k@yagu-yagu.jp', 96),
       ('Ingmar', 'Bergman', 'Sweden', 'Ibergman@outlook.com', 88),
       ('Federico', 'Fellini', 'Italy', 'fedelifellini@lamail.it', 82),
       ('Quincy', 'Jones', 'USA', 'quincy@gmail.com', 82),
       ('Akira', 'Sato', 'Japan', 'akiro.s@yagu-yagu.jp', 76),
       ('Lucia', 'Moretti', 'Italy', 'moretti@lucia.com', 85),
       ('Hans', 'Andersen', 'Denmark', 'admin@andersen.hans.com', 78),
       ('Marta', 'Gomez', 'Spain', 'real.gomez.marta@gmail.com', 92),
       ('Sergei', 'Ivanov', 'Russia', 'sergei-vasya@rambler.ru', 84);

set @avg_usa_rating := (select round(avg(rating), 2) from Directors where country = "USA");
select @avg_usa_rating;

set @min_usa_rating := (select min(rating) from Directors where country = "USA");
select @min_usa_rating as min_usa_rating;

select name, surname, rating into @name, @surname, @rating from Directors where rating = (select min(rating) from Directors where country = "USA");
select @name, @surname, @rating;

