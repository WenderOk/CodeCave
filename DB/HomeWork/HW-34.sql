/* 1 */
delimiter //
create function NON_SPACE_CHARACTERS(string varchar(1000))
returns int
deterministic
begin
    declare result int;
    set result = CHAR_LENGTH(replace(string, ' ', ''));
    return result;
end //
delimiter ;

select NON_SPACE_CHARACTERS(' Bee Geek ');

/* 2 */
delimiter //
create function SAME_DIGITS(number int)
returns int
deterministic
begin
    return case 
        when replace(cast(number as char), LEFT(cast(number as char), 1), '') = '' 
        then 1 
        else 0 
    end;
end //
delimiter ;

select SAME_DIGITS(11111);
select SAME_DIGITS(11121);

/* 3 */
delimiter //
create function CALCULATE(a float, b float, operation char(1))
returns float
deterministic
begin
    declare result float;
    case operation
        when '+' then set result = a + b;
        when '-' then set result = a - b;
        when '*' then set result = a * b;
        when '/' then set result = a / b;
        else set result = NULL;
    END case;
    return result;
end //
delimiter ;

select CALCULATE(-23.25, -55.89, '+');
select CALCULATE(-12.55, 72.91, '-');
select CALCULATE(21.88, -98.34, '*');
select CALCULATE(-99.18, 23.52, '/');
select CALCULATE(-7.13, 57.2, '+');
select CALCULATE(-87.52, -66.18, '-');

/* 4 */
delimiter //
create function MIDDLE_POINT(x1 int, y1 int, x2 int, y2 int)
returns varchar(50)
deterministic
begin
    declare mid_x float;
    declare mid_y float;
    set mid_x = (x1 + x2) / 2.0;
    set mid_y = (y1 + y2) / 2.0;
    return concat('(', format(mid_x, 1), '; ', format(mid_y, 1), ')');
end //
delimiter ;

select MIDDLE_POINT(1, 2, 3, 4);
select MIDDLE_POINT(-19, 34, -80, 72);

/* 5 */
delimiter //
create function LAST_SECOND_DIGIT(number int)
returns int
deterministic
begin
    declare num_str varchar(20);
    declare str_len int;
    set num_str = cast(number as char);
    set str_len = CHAR_LENGTH(num_str);
    if str_len >= 2 then
        return cast(substring(num_str, str_len - 1, 1) as UNSIGNED);
    else
        return NULL;
    end if;
end //
delimiter ;

SELECT LAST_SECOND_DIGIT(1234);
SELECT LAST_SECOND_DIGIT(1);

