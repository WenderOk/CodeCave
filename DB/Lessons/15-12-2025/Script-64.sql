with recursive alphabet as (
	select 65 as n
	union 
	select n+1
	from alphabet
	where n < 90
)
select convert(char(n), char) from alphabet;

with recursive T (n,r) as (
	select 1, 1
	union
	select n + 1, r * (n + 1) from T
	limit 20
)

with recursive T as (
	select floor(10 + rand() * 41) as number
	union all
	select floor(10 + rand() * 41)
	from T limit 20
)
select * from T;