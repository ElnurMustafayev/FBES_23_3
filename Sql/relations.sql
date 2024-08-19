create database MyDatabase
use MyDatabase


-- ONE-TO-MANY
create table Countries (
	[Id] int primary key,
	[Name] nvarchar(50) not null,
	[Popularity] bigint null
)

insert into Countries([Id], [Name])
values	(7, N'Россия'),
		(994, N'Azərbaycan')


create table Teachers (
	[Id] int primary key identity,
	[Name] nvarchar(30) not null,
	[Salary] money not null,
	[CountryId] int foreign key references Countries([Id]) not null
)

insert into Teachers ([Name], [Salary], [CountryId])
values	('Bob', 1500, 994),
		('Ann', 1500, 7),
		('John', 850, 7);

select t.Name, c.Name
from Teachers t
join Countries c on t.CountryId = c.Id



-- MANY-TO-MANY

-- Teachers			Groups
-- 'bob'			'group A'
-- 'elnur'			'group B'

-- TeachersGroups
-- (PK) Id
-- (FK) TeacherId	(references Teachers(Id))
-- (FK) GroupId		(references Groups(Id))

-- TeachersGroups
-- 1, 'bob', 'group A'
-- 2, 'bob', 'group B'
-- 3, 'elnur', 'group B'
-- 4, 'bob', 'group Q'

create table Groups (
	[Id] int primary key identity,
	[Name] varchar(30) not null,
	[StudentsCount] int null
)

insert into Groups([Name])
values ('FBES_Nov_23_3_ru'), ('FBES_22_2_5_ru'), ('FBES_1229_ru')



create table TeachersGroups (
	[Id] int primary key identity,
	[TeacherId] int foreign key references Teachers([Id]) not null,
	[GroupId] int foreign key references Groups([Id]) not null,
)

select *
from Teachers t

select *
from Groups g

-- Bob (Germany) - FBES_Nov_23_3_ru
-- Elnur (Azerbaijan) - FBES_Nov_23_3_ru, FBES_22_2_5_ru, FBES_1229_ru

insert into TeachersGroups (TeacherId, GroupId)
values	(1, 1),
		(4, 1),
		(4, 2),
		(4, 3)



-- Вывести на экран список преподавателей группы 'FBES_Nov_23_3_ru'
select t.Name
from TeachersGroups tg
join Teachers t on tg.TeacherId = t.Id
join Groups g on tg.GroupId = g.Id
where g.Name = 'FBES_Nov_23_3_ru'

-- Вывести на экран список групп преподавателя 'Elnur'
select g.Name
from TeachersGroups tg
join Teachers t on tg.TeacherId = t.Id
join Groups g on tg.GroupId = g.Id
where t.Name = 'Elnur'