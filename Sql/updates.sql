drop table Users

create table Users (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT (NEWID()), 
	[Name] varchar(50) not null,
	[Surname] varchar(50) not null,
	[Gender] bit,
	[Birthdate] datetime2 check([Birthdate] > '1900-01-01')
)

insert into Users ([Name], [Surname], [Gender], [Birthdate])
values	('Ann', 'Brown', 1, '1995-06-09'),
		('Bob', 'Marley', 1, '1945-02-06')

select *
from Users
where Id = '58776DC0-DA59-493D-8D99-A75239F35744'


update Users
set [Surname] = 'Brown'
where Id = '58776DC0-DA59-493D-8D99-A75239F35744'

update Users
set [Gender] = 0, [Id] = '58776DC0-DA59-493D-8D99-A75239F35745'
where [Name] = 'Ann'




drop table Users
create table Users (
	[Id] int primary key identity,
	[Name] varchar(50) not null,
	[Surname] varchar(50) not null,
	[Gender] bit,
	[Birthdate] datetime2 check([Birthdate] > '1900-01-01')
)

insert into Users ([Name], [Surname], [Gender], [Birthdate])
values	('Ann', 'Brown', 1, '1995-06-09'),
		('Bob', 'Marley', 1, '1945-02-06')

select *
from Users

update Users
set Id = 2
where Id = 2

update Users
set Name = 'TEST'
where 1 <> 1 or 1 = 1