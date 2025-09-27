DROP TABLE IF EXISTS Songs;
CREATE TABLE Songs(
    id INTEGER PRIMARY KEY,
    place INTEGER,
    trackname TEXT,
    artist TEXT,
    streams INTEGER,
    release_date DATE
);
INSERT INTO Songs (id, place, trackname, artist, streams, release_date)
VALUES (1, 4, 'Crazy On You', 'Heart', 76338, '2009-12-19'),
       (2, 3, 'My Lover', 'The Sounds', 99488, '2009-05-31'),
       (3, 2, 'Running up That Hill', 'Kate Bush', 121495, '1985-08-05'),
       (4, 5, 'Thrill', 'The Sounds', 49345, '2016-11-11'),
       (5, 1, 'Spent the Day in Bed', 'Morrissey', 174994, '2017-10-17');
