-- DROP TABLE IF EXISTS Directors;
-- CREATE TABLE Directors(
--     id      INT PRIMARY KEY AUTO_INCREMENT,
--     name    VARCHAR(40),
--     surname VARCHAR(40),
--     country VARCHAR(40),
--     email VARCHAR(40)
-- );
-- 
-- INSERT INTO Directors (name, surname, country, email)
-- VALUES ('Christopher', 'Nolan', 'England', 'chris@gmail.com'),
--        ('Steven', 'Spielberg', 'USA', 'sspil@outlook.com'),
--        ('Quentin', 'Tarantino', 'USA', 'queen@gmail.com'),
--        ('Martin', 'Scorsese', 'USA', 'martins@outlook.com'),
--        ('David', 'Fincher', 'USA', 'dfincher@outlook.com'),
--        ('Ridley', 'Scott', 'England', 'riddler@gmail.com'),
--        ('Stanley', 'Kubrick', 'USA', 'bigstan@icloud.com'),
--        ('Clint', 'Eastwood', 'USA', 'cowboy@yahoo.com'),
--        ('James', 'Cameron', 'Canada', 'jamesava@yahoo.com'),
--        ('Tim', 'Burton', 'USA', 'timmy@icloud.com');

select name, surname, 
lpad(right(email, length(email) - locate("@",email)+1), length(email), "*") as email 
from Directors order by email;