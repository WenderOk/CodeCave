-- 
-- DROP TABLE IF EXISTS Ranges;
-- CREATE TABLE Ranges(
--     id INT PRIMARY KEY AUTO_INCREMENT,
--     a  INT,
--     b  INT
-- );
-- 
-- INSERT INTO Ranges (a, b)
-- VALUES (0, 180),
--        (-1, 1),
--        (-10, 10),
--        (-90, 90),
--        (10, 100);

select concat("[", a, "; ", b, "]") as "range", round(a + rand() * (b - a + 1), 0) as random_value from Ranges order by id;