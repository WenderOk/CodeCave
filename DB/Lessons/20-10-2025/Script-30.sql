-- DROP TABLE IF EXISTS Math;
-- CREATE TABLE Math(
--     id      INT PRIMARY KEY AUTO_INCREMENT,
--     name    VARCHAR(20),
--     surname VARCHAR(20),
--     grade   CHAR(2)
-- );
-- 
-- INSERT INTO Math (name, surname, grade)
-- VALUES ('Flash', 'Thompson', 'D'),
--        ('Peter', 'Parker', 'A'),
--        ('Mary', 'Jane', 'D'),
--        ('Gwen', 'Stacy', 'B'),
--        ('Harry', 'Osborn', 'A'),
--        ('Ben', 'Reilly', 'E'),
--        ('Miles', 'Morales', 'A'),
--        ('John', 'Jameson', 'E'),
--        ('Curtis', 'Connors', 'B'),
--        ('Edward', 'Brock', 'C');

select name, surname, case grade when "A" then 5 when "B" then 4 when "C" then 3 when "D" then 2 when "E" then 1 end as grade from Math order by grade desc, name;
select name, surname, case grade 
when "A" then "Great"
	when "B" then "Great" 
	when "C" then "Well" 
	when "D" then "Bad" 
	when "E" then "Bad"
end as grade from Math order by grade, name;