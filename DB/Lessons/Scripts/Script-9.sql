-- DROP TABLE IF EXISTS Songs;
-- CREATE TABLE Songs(
--     id        INT PRIMARY KEY AUTO_INCREMENT,
--     place     INT,
--     trackname VARCHAR(30),
--     artist    VARCHAR(30),
--     price     DECIMAL(10, 2),
--     quantity  INT
-- );
-- 
-- INSERT INTO Songs (place, trackname, artist, price, quantity)
-- VALUES (4, 'Crazy On You', 'Heart', 2.00, 31454),
--        (3, 'My Lover', 'The Sounds', 3.00, 4558),
--        (2, 'Running up That Hill', 'Kate Bush', 1.00, 15874),
--        (5, 'Thrill', 'The Sounds', 5.00, 548),
--        (1, 'Spent the Day in Bed', 'Morrissey', 5.00, 564797);

-- select trackname, price * quantity as total from songs order by total;
select trackname, price * quantity as total from songs order by total;