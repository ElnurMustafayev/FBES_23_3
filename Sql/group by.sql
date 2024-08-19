create database MyDatabase
use MyDatabase

create table Countries (
	[Id] int primary key,
	[Name] nvarchar(50) not null,
	[Popularity] bigint null
)

insert into Countries([Id], [Name])
values	(45, N'Germany'),
		(7, N'Россия'),
		(994, N'Azərbaycan')

create table Teachers (
	[Id] int primary key identity,
	[Name] nvarchar(30) not null,
	[Salary] money not null,
	[CountryId] int foreign key references Countries([Id]) not null
)

insert into Teachers ([Name], [Salary], [CountryId])
values	('Bob', 1500, 45),
		('Ann', 1500, 7),
		('Bob', 1500, 994),
		('John', 850, 7);



-- Вывести на экран страну и количество преподавателей в ней соответственно
-- |Russia		| 2 |
-- |Germany		| 1 |
-- |Azerbaijan	| 1 |

select t.CountryId, count(*)
from Teachers t
group by t.CountryId

select c.Name, count(*)
from Teachers t
join Countries c on t.CountryId = c.Id
group by c.Name



-- Средняя зарплата по каждой стране
select *
from Teachers t

select t.CountryId, avg(t.Salary) as 'Avg salary'
from Teachers t
group by t.CountryId

-- Количество тёсок
select t.Name, avg(t.Salary), count(*)
from Teachers t
group by t.Name
having avg(t.Salary) > 1000

select distinct t.Name
from Teachers t



--select *
--from Teachers t

--union all

--select *
--from Teachers t