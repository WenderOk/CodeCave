DROP TABLE IF EXISTS Programmers;
DROP TABLE IF EXISTS Physicists;
DROP TABLE IF EXISTS Mathematicians;

CREATE TABLE Mathematicians(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(30),
    surname VARCHAR(30)
);

INSERT INTO Mathematicians(name, surname)
VALUES
    ('Leonhard', 'Euler'),
    ('Carl', 'Gauss'),
    ('Isaac', 'Newton'),
    ('Euclid', 'Alexandria'),
    ('Albert', 'Einstein'),
    ('John', 'Milnor'),
    ('Blaise', 'Pascal'),
    ('Rene', 'Descartes'),
    ('Andrew', 'Wiles'),
    ('Srinivasa', 'Ramanujan'),
    ('John', 'Nash'),
    ('Kurt', 'Godel'),
    ('John', 'Milnor'),
    ('Blaise', 'Pascal'),
    ('Rene', 'Descartes'),
    ('Andrew', 'Wiles'),
    ('Srinivasa', 'Ramanujan'),
    ('John', 'Nash'),
    ('Kurt', 'Godel'),
    ('Alan', 'Turing'),
    ('Grace', 'Hopper'),
    ('Linus', 'Torvalds'),
    ('Tim', 'Berners'),
    ('Ada', 'Lovelace'),
    ('John', 'Neumann'),
    ('Dennis', 'Ritchie'),
    ('Tim', 'Peters'),
    ('Donald', 'Knuth'),
    ('Larry', 'Page');

CREATE TABLE Physicists(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(30),
    surname VARCHAR(30)
);
INSERT INTO Physicists(name, surname)
VALUES
    ('Richard', 'Muller'),
    ('Isaac', 'Newton'),
    ('Galileo', 'Galilei'),
    ('Niels', 'Bohr'),
    ('Richard', 'Feynman'),
    ('Werner', 'Heisenberg'),
    ('Stephen', 'Hawking'),
    ('Enrico', 'Fermi'),
    ('Richard', 'Feynman'),
    ('Niels', 'Bohr'),
    ('Brian', 'Greene'),
    ('Lisa', 'Randall');

CREATE TABLE Programmers(
    id      INT PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(30),
    surname VARCHAR(30)
);
INSERT INTO Programmers (name, surname)
VALUES
    ('Alan', 'Turing'),
    ('Grace', 'Hopper'),
    ('Linus', 'Torvalds'),
    ('Tim', 'Berners'),
    ('Ada', 'Lovelace'),
    ('John', 'Neumann'),
    ('Dennis', 'Ritchie'),
    ('Tim', 'Peters'),
    ('Donald', 'Knuth'),
    ('Larry', 'Page'),
    ('Bjarne', 'Stroustrup'),
    ('Margaret', 'Hamilton'),
    ('Ken', 'Thompson'),
    ('Yukihiro', 'Matsumoto'),
    ('Larry', 'Wall');


select "Ma" as prof, count(*) as total from Mathematicians
union
select "Py", count(*) from Physicists
union
select "Pr", count(*) from Programmers;

select name, surname from 
(select name, surname, 1 as prof from Mathematicians
union
select name, surname, 2 from Physicists
union
select name, surname, 3 from Programmers
order by prof, name desc) as tmp;