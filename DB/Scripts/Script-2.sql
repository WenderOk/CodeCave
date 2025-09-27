--DROP TABLE IF EXISTS Films;
--CREATE TABLE Films(
--    id           INTeger PRIMARY KEY,
--    director     text,
--    title        text,
--    release_date year
--);

INSERT INTO Films (title, director, release_date)
VALUES ('The Incredibles', 'Brad Bird', '2004'),
       ('WALL-E', 'Andrew Stanton', '2008'),
       ('Inside Out', 'Pete Docter', '2015'),
       ('The Good Dinosaur', 'Peter Sohn', '2015'),
       ('Ratatouille', 'Brad Bird', '2007');