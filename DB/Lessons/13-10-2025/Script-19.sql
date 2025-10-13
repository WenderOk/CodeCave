-- DROP TABLE IF EXISTS PrimeNumbers;
-- CREATE TABLE PrimeNumbers(
--     num INTEGER
-- );
-- 
-- INSERT INTO PrimeNumbers(num)
-- VALUES (2),
--        (3),
--        (5),
--        (7),
--        (11),
--        (13),
--        (17),
--        (19),
--        (23),
--        (29);

select conv(num,10,2) as bin, conv(num,10,8) as oct, conv(num,10,16) as hex from PrimeNumbers order by num desc;