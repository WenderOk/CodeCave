DROP TABLE IF EXISTS Grades;
DROP TABLE IF EXISTS Classes;
DROP TABLE IF EXISTS Students;

CREATE TABLE Students(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    student VARCHAR(40)
);
INSERT INTO Students(student)
VALUES ('Peter Parker'),
       ('Mary Jane'),
       ('Gwen Stacy');

CREATE TABLE Classes(
    id   INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(20)
);
INSERT INTO Classes(name)
VALUES ('Math'),
       ('Chemistry'),
       ('Biology');
truncate Grades;
CREATE TABLE Grades(
    student_id INT,
    class_id   INT,
    grade      INT
);
INSERT INTO Grades(student_id, class_id, grade)
VALUES (3, 3, 5),
       (1, 1, 5),
       (3, 1, 4),
       (1, 2, 5),
       (2, 1, 3),
       (2, 2, 4),
       (1, 3, 5),
       (2, 3, 3),
       (3, 2, 5);

select * from Grades;
update Grades set grade = 5 where grade = 4;
update grades set grade = 5 where student_id = (select id from Students where student = "Peter Parker")
select * from Grades;