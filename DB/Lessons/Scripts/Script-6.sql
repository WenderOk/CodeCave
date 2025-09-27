--DROP TABLE IF EXISTS Films2;
--CREATE TABLE Films2(
--    id           integer PRIMARY KEY,
--    title        text,
--    director     TEXT,
--    release_year YEAR,
--    running_time integer
--);

INSERT INTO Films2 (title, director, release_year, running_time) 
VALUES ('Toy Story 2', 'John Lasseter', 1999, 93),
       ('WALL-E', 'Andrew Stanton', 2008, 104),
       ('Ratatouille', 'Brad Bird', 2007, 115),
       ('Up', 'Pete Docter', 2009, 101),
       ('Brave', 'Brenda Chapman', 2012, 102),
       ('Monsters University', 'Dan Scanlon', 2013, 110),
       ('Cars 2', 'John Lasseter', 2011, 120),
       ('Finding Nemo', 'Andrew Stanton', 2003, 107),
       ('Toy Story', 'John Lasseter', 1995, 81),
       ('The Incredibles', 'Brad Bird', 2004, 116);