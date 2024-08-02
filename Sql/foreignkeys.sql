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

create table Users (
	[Id] int primary key identity,
	[Name] nvarchar(50) not null,
	[BirthDate] datetime2 null,
	[CountryId] int foreign key references Countries([Id])
)

insert into Users ([Name], [BirthDate], [CountryId])
values	('Bob', '1945-02-15', 994),
		('Ann', '2000-01-20', 7),
		('John', '1991-10-16', 7)

select *
from Users