DROP TABLE IF EXISTS Files;
CREATE TABLE Files(
    id                  INT PRIMARY KEY AUTO_INCREMENT,
    name                VARCHAR(40),
    parent_directory_id INT
);

INSERT INTO Files(name, parent_directory_id)
VALUES ('desktop', NULL),
       ('test', 1),
       ('Картинки', 2),
       ('1.jpg', 3),
       ('avatar.png', 3),
       ('certificate.png', 3),
       ('py.png', 3),
       ('World_Time_Zones_Map.png', 3),
       ('Снимок экрана.png', 3),
       ('Неравенства.djvu', 2),
       ('Программы', 2),
       ('image_util.py', 11),
       ('sort.py', 11),
       ('Разные файлы', 2),
       ('astros.json', 14);
