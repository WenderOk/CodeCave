-- DROP TABLE IF EXISTS Songs;
-- CREATE TABLE Songs(
--     id INT PRIMARY KEY AUTO_INCREMENT,
--     place INT,
--     trackname VARCHAR(30),
--     artist VARCHAR(30),
--     streams INT,
--     release_date DATE
-- );
-- INSERT INTO Songs (place, trackname, artist, streams, release_date)
-- VALUES (4, 'Crazy On You', 'Heart', 76338, '2009-12-19'),
--        (3, 'My Lover', 'The Sounds', 99488, '2009-05-31'),
--        (2, 'Running up That Hill', 'Kate Bush', 121495, '1985-08-05'),
--        (5, 'Thrill', 'The Sounds', 49345, '2016-11-11'),
--        (1, 'Spent the Day in Bed', 'Morrissey', 174994, '2017-10-17');

-- select artist, char_length(artist) as length from songs;
-- select artist, lower(trackname) as trackname from songs;
-- select artist, reverse(upper(trackname)) as trackname from songs;
select artist, lpad(reverse(artist), 20, '!') as result from songs;