-- select title from films where running_time < (select min(running_time) from films where director = "John Lasseter");
-- select count(title) as shortest_films from films where running_time = (select min(running_time from films);
-- DROP TABLE IF EXISTS RequestsAccepted;
-- DROP TABLE IF EXISTS FriendRequests;
-- 
-- CREATE TABLE FriendRequests(
--     sender_id    INT,
--     send_to_id   INT,
--     request_date DATE
-- );
-- INSERT INTO FriendRequests(sender_id, send_to_id, request_date)
-- VALUES (1, 2, '2023-06-01'),
--        (1, 2, '2023-06-02'),
--        (1, 3, '2023-06-01'),
--        (1, 3, '2023-06-21'),
--        (2, 1, '2023-06-12'),
--        (2, 1, '2023-06-23'),
--        (2, 3, '2023-06-02'),
--        (3, 1, '2023-06-12'),
--        (3, 2, '2023-06-13'),
--        (3, 4, '2023-06-09'),
--        (4, 1, '2023-06-25'),
--        (4, 2, '2023-06-29'),
--        (4, 3, '2023-06-15'),
--        (4, 5, '2023-06-10'),
--        (5, 3, '2023-06-21'),
--        (5, 3, '2023-06-28'),
--        (5, 4, '2023-06-16'),
--        (5, 6, '2023-06-11'),
--        (5, 6, '2023-06-11'),
--        (6, 5, '2023-06-20');
-- CREATE TABLE RequestsAccepted(
--     requester_id INT,
--     accepter_id  INT,
--     accept_date  DATE
-- );
-- INSERT INTO RequestsAccepted(requester_id, accepter_id, accept_date)
-- VALUES (1, 2, '2023-06-02'),
--        (1, 2, '2023-06-02'),
--        (1, 3, '2023-06-23'),
--        (2, 3, '2023-06-02'),
--        (3, 1, '2023-06-15'),
--        (3, 2, '2023-06-14'),
--        (3, 4, '2023-06-19'),
--        (4, 1, '2023-06-25'),
--        (4, 1, '2023-06-25'),
--        (4, 2, '2023-06-30'),
--        (5, 3, '2023-06-21'),
--        (5, 3, '2023-06-28'),
--        (5, 4, '2023-06-17'),
--        (5, 6, '2023-06-15'),
--        (6, 5, '2023-06-20');

select sender_id, send_to_id, request_date from friendrequests where (select distinct requester_id, accepter_id, accept_date from requestsaccepted);
select  distinct requester_id, accepter_id from requestsaccepted;



