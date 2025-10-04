/*1*/
select * from Pups where age in (5,6,7,8);
/*2*/
select * from Pups where name!='Снежок';
/*3*/
select * from Pups where age=6 or price=12000;
/*4*/
select * from Pups where age between 5 and 8 or price=5000;
/*5*/
select * from  Pups where age between 7 and 40 or price between 6000 and 13000;
/*6*/
select * from Pups where age = 6 or price <> 7000;
/*7*/
select * from Pups limit 3 offset 5;
/*8*/
select * from Pups order by price;
/*9*/
select * from Pups order by Age desc limit 5 offset 1;