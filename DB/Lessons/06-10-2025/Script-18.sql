DROP TABLE IF EXISTS Sizes;
CREATE TABLE Sizes(
    id              INT PRIMARY KEY AUTO_INCREMENT,
    nominal_size    INT,
    limit_deviation DECIMAL(3, 2),
    actual_size     DECIMAL(4, 2)
);

INSERT INTO Sizes (nominal_size, limit_deviation, actual_size)
VALUES (18, 0.3, 17.7),
       (26, 0.2, 25.6),
       (14, 0.4, 14.1),
       (42, 0.9, 41),
       (36, 0.3, 36),
       (24, 0.1, 24.2),
       (8, 0.2, 7.9),
       (4.3, 0.2, 4.1),
       (1, 0.5, 1.5),
       (49, 1, 47);