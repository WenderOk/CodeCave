DROP TABLE IF EXISTS Directors;
CREATE TABLE Directors(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(40),
    surname VARCHAR(40),
    country VARCHAR(40),
    rating  INT
);

INSERT INTO Directors (name, surname, country, rating)
VALUES ('Christopher', 'Nolan', 'England', 90),
       ('Steven', 'Spielberg', 'USA', 79),
       ('Quentin', 'Tarantino', 'USA', NULL),
       ('Martin', 'Scorsese', 'USA', 68),
       ('David', 'Fincher', 'USA', 100),
       ('Ridley', 'Scott', 'England', 54),
       ('Stanley', 'Kubrick', 'USA', 9),
       ('Clint', 'Eastwood', 'USA', 74),
       ('James', 'Cameron', 'Canada', NULL),
       ('Tim', 'Burton', 'USA', NULL);

select count(*) into @num_of_rated_directors from Directors where rating is not null;
select @num_of_rated_directors;