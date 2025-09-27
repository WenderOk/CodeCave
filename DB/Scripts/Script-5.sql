--DROP TABLE IF EXISTS Films;
--CREATE TABLE Films(
--    id           INT PRIMARY KEY,
--    title        TEXT,
--    director     TEXT,
--    release_date DATE,
--    duration     TIME
--);

INSERT INTO Films (id, title, director, release_date, duration)
VALUES (1, 'The Incredibles', 'Brad Bird', '2004-12-25', '1:45'),
       (2, 'WALL-E', 'Andrew Stanton', '2008-07-03', '1:39'),
       (3, 'Inside Out', 'Pete Docter', '2015-06-19', '1:35'),
       (4, 'The Good Dinosaur', 'Peter Sohn', '2015-11-25', '1:35'),
       (5, 'Ratatouille', 'Brad Bird', '2007-06-28', '1:41');