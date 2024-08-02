create table Countries (
	[Id] int primary key,
	[Name] nvarchar(50) not null,
	[Popularity] bigint null
)

insert into Countries([Id], [Name])
values	(7, N'Россия'),
		(994, N'Azərbaycan')

select *
from Countries





create table Departments (
	[Id] int primary key,
	[Name] nvarchar(30) not null,
	[Description] nvarchar(100) null
)

insert into Departments([Id], [Name], [Description])
values	(1, 'IT', 'Cyber Security'),
		(2, 'Design', 'Photoshop'),
		(3, 'Programming', 'Sql')

select *
from Departments





create table Teachers (
	[Id] int primary key identity,
	[Name] nvarchar(30) not null,
	[Surname] nvarchar(30) not null,
	[Salary] money not null,
	[DepartmentId] int foreign key references Departments([Id]) not null,
	[CountryId] int foreign key references Countries([Id]) null
)

insert into Teachers ([Name], [Surname], [Salary], [DepartmentId], [CountryId])
values	('Bob', 'Marley', 1500, 1, 994),
		('Ann', 'Merley', 1500, 1, 7),
		('John', 'Brown', 850, 2, null),
		('Kate', 'White', 900, 2, 7),
		('Anthon', 'Davidov', 2200, 3, 7),
		('Igor', 'Test', 2150, 3, 994)

select *
from Teachers


create table Groups (
	[Id] int primary key identity,
	[Name] varchar(30) not null,
	[TeacherId] int foreign key references Teachers([Id]) null
)

insert into Groups([Name], [TeacherId])
values ('FBES_Nov_23_3_ru', 1)



--GroupsTeachers
--(1, 2),
--(1, 3),
--(1, 7)

--select *
--from GroupsTeachers gt
--join Teachers t on t.Id = gt.TeacherId
--where gt.GroupId = 1



select c.Name 
from Groups g
join Teachers t on g.TeacherId = t.Id
join Countries c on t.CountryId = c.Id
where TeacherId is not null





select *
from Departments
where Id =	(select DepartmentId
			from Teachers
			where Name = 'Ann')

select t.Name, d.Name
from Teachers t
join Departments d on t.DepartmentId = d.Id
--join Departments on 1 = 1


select d.Name, t.Name, c.Name
from Departments d
join Teachers t on t.DepartmentId = d.Id
join Countries c on t.CountryId = c.Id
where d.Name = 'IT'
