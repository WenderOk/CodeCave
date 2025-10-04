use HomwWork;
/*1*/
select * from Pups where id=11; /*Только он выдаст ошибку, потому что у нас тлько 10 записей*/
/*2*/
select * from Pups where price=15000;
/*3*/
select * from Pups where price>=1000;
/*4*/
select * from Pups where age>=20;
/*5*/
select * from Pups where price<4000;
/*6*/
select * from Pups where price!=5000;
/*7*/
select * from Pups where name='Хатико';
/*8*/
select * from Pups where price>=5000;
/*9*/
select * from Pups where price<=9000;
/*10*/
select name from Pups where id=9;
/*11*/
select name from Pups where name!='Снежок';
/*12*/
select distinct age from Pups;
/*13*/
select name from Pups limit 5;
/*14*/
select name from Pups limit 10 offset 5	;