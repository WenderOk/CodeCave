-- DROP TABLE IF EXISTS Scores;
-- CREATE TABLE Scores(
--     id    INT PRIMARY KEY AUTO_INCREMENT,
--     score DECIMAL(4, 2)
-- );
-- INSERT INTO Scores(score)
-- VALUES (3.50),
--        (3.50),
--        (4.00),
--        (3.50),
--        (4.20),
--        (3.65),
--        (4.20),
--        (3.65),
--        (4.20),
--        (3.95),
--        (4.05),
--        (3.65),
--        (4.05),
--        (3.70),
--        (3.80),
--        (4.25),
--        (3.55),
--        (4.40),
--        (4.30),
--        (4.40);

select score, (select count(distinct score) from Scores where score >= S.score) as gamer_rank from Scores as S order by gamer_rank desc;

