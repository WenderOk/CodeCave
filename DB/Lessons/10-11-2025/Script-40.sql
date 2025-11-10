-- DROP TABLE IF EXISTS Math;
-- CREATE TABLE Math(
--     id      INT PRIMARY KEY AUTO_INCREMENT,
--     name    VARCHAR(20),
--     surname VARCHAR(20),
--     grade   INT
-- );
-- 
-- TRUNCATE Math;
-- INSERT INTO Math (name, surname, grade)
-- VALUES ('Flash', 'Thompson', 2),
--        ('Peter', 'Parker', 2),
--        ('Mary', 'Jane', 3),
--        ('Gwen', 'Stacy', 2),
--        ('Harry', 'Osborn', 3),
--        ('May', 'Parker', 4),
--        ('Miles', 'Morales', 2),
--        ('John', 'Jameson', 1),
--        ('Norman', 'Osborn', 5),
--        ('Ben', 'Parker', 3),
--        ('Yuriko', 'Watanabe', 3),
--        ('Martin', 'Li', 4),
--        ('Sergei', 'Kravinoff', 5),
--        ('Felicia', 'Hardy', 1),
--        ('Aaron', 'Davis', 1),
--        ('Rio', 'Morales', 4),
--        ('Robbie', 'Robertson', 3),
--        ('Hailey', 'Cooper', 5),
--        ('John', 'Howard', 2),
--        ('Flint', 'Marco', 3),
--        ('Eddie', 'Brock', 4),
--        ('Felicia', 'Hardy', 3),
--        ('Cindy', 'Moon', 2),
--        ('Anya', 'Corazon', 4),
--        ('Ezekiel', 'Simmons', 5),
--        ('Mac', 'Gargan', 3),
--        ('Gwen', 'Pool', 2),
--        ('Hobie', 'Brown', 4),
--        ('Cletus', 'Kasady', 1),
--        ('Jessica', 'Drew', 3);

select name, surname, grade from Math as M where grade > (select avg(grade) from Math where id < M.id) order by grade, name;
select name, surname, grade from Math as M where grade = any (select grade from Math where id in (M.id - 1, M.id + 1)) order by name;
select name, surname, grade from Math as M where grade = (select grade from Math group by grade order by count(*) desc limit 1) order by name;
select name, surname, grade from Math as M where 1 < (select count(surname) from Math where surname = M.surname) order by surname, name;