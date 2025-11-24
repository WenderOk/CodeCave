DROP TABLE IF EXISTS FemaleStaff;
DROP TABLE IF EXISTS MaleStaff;

CREATE TABLE MaleStaff(
  id      INT PRIMARY KEY AUTO_INCREMENT,
  staffer VARCHAR(50),
  age     INT
);
INSERT INTO MaleStaff(staffer, age) VALUES
  ('Larry Page', 48),
  ('Sundar Pichai', 49),
  ('Eric Schmidt', 66),
  ('Jeff Dean', 49),
  ('Hiroshi Lockheimer', 43);

CREATE TABLE FemaleStaff(
  id      INT PRIMARY KEY AUTO_INCREMENT,
  staffer VARCHAR(50),
  age     INT
);
INSERT INTO FemaleStaff(staffer, age) VALUES
  ('Susan Wojcicki', 53),
  ('Ruth Porat', 63),
  ('Aparna Chennapragada', 48);


select MaleStaff.staffer as male_staffer, FemaleStaff.staffer as female_staffer
from maleStaff cross join FemaleStaff
where abs(MaleStaff.age - FemaleStaff.age) < 5
order by male_staffer, female_staffer;