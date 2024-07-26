create database MyDatabase
use MyDatabase

create table Users (
	[Name] varchar(50) not null,
	[Surname] varchar(50) not null,
	[Gender] bit,
	[Birthdate] datetime2
)

insert into Users ([Name], [Surname], [Gender])
values('Imran', 'Majidov', 1)

insert into Users ([Name], [Surname])
values('Arzu', 'Brown')

insert into Users ([Gender], [Name], [Surname])
values(0, 'Ann', 'White')

insert into Users ([Name], [Surname])
values	('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley'),
		('Bob', 'Marley')

insert into Users ([Name], [Surname], [Gender], [Birthdate])
values('Ann', 'White', 0, '1989-01-17'),
('Ann', 'White', 0, '1989-17-01')



-- CRUD
-- create	insert
-- read		select
-- update	update
-- delete	delete