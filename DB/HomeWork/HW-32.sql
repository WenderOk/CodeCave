/* 1 */
select airport_id
from (
    select airport_id, sum(flights_count) as total_traffic
    from (
        select departure_airport as airport_id, flights_count from Flights
        union all
        select arrival_airport as airport_id, flights_count from Flights
    ) as AllAirports
    group by airport_id
) as Trafficsummary

where total_traffic = (
    select max(total_traffic)
    from (
        select airport_id, sum(flights_count) as total_traffic
        from (
            select departure_airport as airport_id, flights_count from Flights
            union all
            select arrival_airport as airport_id, flights_count from Flights
        ) as t1
        group by airport_id
    ) as t2
);

/* 2 */
with CompanyTaxRates as (
    select company_id,
        case
            when max(salary) < 1000 then 0.00
            when max(salary) between 1000 and 10000 then 0.24
            when max(salary) > 10000 then 0.49
        end as tax_rate
    from Salaries
    group by company_id
)
select employee_id as id, employee_name as name, round(salary * (1 - tax_rate)) as salary
from Salaries as s
join CompanyTaxRates as ctr on s.company_id = ctr.company_id
order by id;

/* 3 */
with VoterVotes as (
    select voter, count(candidate) as candidate_count
    from Votes group by voter
), CandidateScores as (
    select v.candidate, sum(1.0 / vv.candidate_count) as total_votes
    from Votes v
    join VoterVotes as vv on v.voter = vv.voter
    where v.candidate is not null
    group by v.candidate
), maxVotes as (
    select max(total_votes) as max_votes
    from CandidateScores
)
select candidate
from CandidateScores as cs
join maxVotes as mv on cs.total_votes = mv.max_votes;

/* 4 */
with PassengerBus as (
    select p.id as passenger_id, p.arrival_time, min(b.id) as bus_id
    from Passengers as p
    join Buses as b on b.departure_time >= p.arrival_time
    group by p.id, p.arrival_time
)
select b.id as bus_id, count(pb.passenger_id) as passenger_count
from Buses as b
left join PassengerBus as pb on b.id = pb.bus_id
group by b.id order by b.id;

/* 5 */
create table Numbers (num int);
insert into Numbers (num) 
values (1), (5), (3), (7), (2);

with recursive AllNumbers as (
    select min(num) as num from Numbers
    union all
    select num + 1 from AllNumbers
    where num < (select max(num) from Numbers)
)
select num from AllNumbers order by num;