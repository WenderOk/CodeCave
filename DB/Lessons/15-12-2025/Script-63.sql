DROP TABLE IF EXISTS Math;
CREATE TABLE Math(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(20),
    surname VARCHAR(20),
    grade   VARCHAR(2)
);

INSERT INTO Math(name, surname, grade)
VALUES ('Flash', 'Thompson', 'D'),
       ('Peter', 'Parker', 'A'),
       ('Mary', 'Jane', 'D'),
       ('Gwen', 'Stacy', 'B'),
       ('Harry', 'Osborn', 'A'),
       ('Ben', 'Reilly', 'E'),
       ('Miles', 'Morales', 'A'),
       ('John', 'Jameson', 'E'),
       ('Curtis', 'Connors', 'B'),
       ('Edward', 'Brock', 'C'),
       ('Yuriko', 'Watanabe', 'C'),
       ('Martin', 'Li', 'B'),
       ('Sergei', 'Kravinoff', 'A'),
       ('Felicia', 'Hardy', 'D'),
       ('Aaron', 'Davis', 'E'),
       ('Rio', 'Morales', 'B'),
       ('Robbie', 'Robertson', 'C'),
       ('Hailey', 'Cooper', 'A'),
       ('John', 'Howard', 'D'),
       ('Flint', 'Marco', 'C');


with GradedText as (
	select if(grade in ('A','B'),
		'Great', if(grade = 'C', 'Well', 'Bad')) as result
	from Math
)
select result,  count(*) as students from GradedText group by result;

with recursive PowerOfTwo as (
	select 1 as degree, 2 as power
	union all select degree + 1, power * 2 from PowerOfTwo limit 10
)
select * from PowerOfTwo;

with recursive PowerOfNumbers as (
	select 1 as number
	union all select pow(sqrt(number) + 1, 2) from PowerOfNumbers limit 10
)
select * from PowerOfNumbers;

with recursive PowerOfNumbers as (
	select 1 as number
	union all select pow(sqrt(number) + 1, 2) from PowerOfNumbers limit 10
)
select * from PowerOfNumbers;

with recursive T as (
	select '2024-12-31' as day
	union
	select day - interval 1 day 
	from T limit 31
	)
select * from T;
	