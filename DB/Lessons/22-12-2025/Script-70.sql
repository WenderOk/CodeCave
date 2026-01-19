delimiter //
create function is_even(number int)
returns int
deterministic
begin
	return if(number mod 2 = 0, 1, 0);
end //
delimiter ;
select is_even(10);

delimiter //
create function vector_abs(x int, y int)
returns float
deterministic
begin
	return sqrt(pow(x, 2) + pow(y, 2));
end //
delimiter ;
select vector_abs(3, 4);