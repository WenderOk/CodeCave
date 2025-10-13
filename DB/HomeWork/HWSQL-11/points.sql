-- DROP TABLE IF EXISTS Points;
-- CREATE TABLE Points(
--     x INT,
--     y INT
-- );
-- 
-- INSERT INTO Points (x, y)
-- VALUES (5, 7),
--        (21, 25),
--        (10, 19),
--        (19, 29),
--        (0, 0),
--        (4, 19),
--        (23, 1),
--        (22, 20),
--        (3, 15),
--        (6, 18);

select x, y, round(sqrt(x * x + y * y), 2) as distance from Points order by distance desc;