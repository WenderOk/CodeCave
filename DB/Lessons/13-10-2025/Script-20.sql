-- DROP TABLE IF EXISTS Angles;
-- CREATE TABLE Angles(
--     angle INTEGER
-- );
-- 
-- INSERT INTO Angles (angle)
-- VALUES (0),
--        (30),
--        (45),
--        (60),
--        (90),
--        (120),
--        (135),
--        (150),
--        (180),
--        (210),
--        (225),
--        (240),
--        (270),
--        (300),
--        (315),
--        (330),
--        (360);

select 
concat(angle,'°') as x, 
format(sin(radians(angle)),1) as 'sin(x)', 
format(cos(radians(angle)),1) as 'cos(x)' 
from Angles order by angle;