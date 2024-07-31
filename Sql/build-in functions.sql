create database MyDatabase

use MyDatabase

create table Products (
    [Id] int primary key identity,
    [Name] nvarchar(50) not null unique,
    [Price] money not null check([Price] >= 0),
    [Status] varchar(30) null default 'in stock',
    [ExpDate] datetime2 null,
)

insert into Products (Name, Price, Status)
values	('Tv', 750, 'in stock'),
		('IPhone 14', 1000, 'out of stock'),
		('Book', 2, 'bestseller'),
		('Car', 30000, 'bestseller'),
		('Remote', 10, null),
		('IPhone 15', 1500, 'in stock')

insert into Products (Name, Price, Status, [ExpDate])
values	('Jane', 45000, 'in stock', '2028-11-04'),
		('Ann', 11000, 'out of stock', '2025-02-23')

select *
from Products

select avg(Price)
from Products

select avg(Price)
from Products
where Price > 1000

select Name, len(Name) as 'Name length'
from Products

select Price, avg(Price)
from Products

select avg(len(Name))
from Products

select sum(Id)
from Products

select max(Price)
from Products

select min(Name)
from Products

select top 2 min(len(Name))
from Products

select count(*)
from Products

select count(Status)
from Products

select UPPER(Name)
from Products

SELECT FORMAT(123456789, '##-##-#####')

select dateadd(year, 30, ExpDate)
from Products
where ExpDate is not null

select *
from Products
where len(Name) >= 4

select *
from Products
where Price > avg(Price)



create table Users(
	[Name] varchar(50) not null,
	[Fincode] varchar(7) not null unique check(len([Fincode]) = 7),
	[IsMarried] bit,
	[BirthDate] datetime2
)
 
insert into Users([Name], [Fincode], [IsMarried], [BirthDate])
values ('John', 'ASDA777' , 0, '01-01-1991'),
('Test', 'ASDAS34' , 0, '01-02-2017'),
('Bob', 'AZ34567' , 1, '10-10-2004'),
('Ann', 'ZY34568', 0, '10-10-2005'),
('Kate', 'YZ34569', 1, '10-10-2000')



-- количество людей в браке
select count(*) from Users where IsMarried = 1
-- количество людей, у которых в именах есть дефис
select count(*) from Users where Name like '%-%'
-- дата рождения самого старшего человека
select min(BirthDate) from Users
-- имена людей, у которых в финкоде есть буква Z и Y
select Name from Users where Fincode like '%Z%' and Fincode like '%Y%'



-- список людей, у которых длина имени превышает среднюю арифметическую длину имен


select *
from Users
where len(Name) > (select avg(len(Name)) from Users)


-- необходимо вывести список всех людей, 
-- у которых дата рождения больше минимальной даты рождения максимум на 10 лет

--datediff
--dateadd
select *
from Users 
--where BirthDate >= (select min(BirthDate) from Users)
where BirthDate <= dateadd(year, 10, (select min(BirthDate) from Users))


-- min: 1956-10-10

-- OK: 1957-10-10
-- OK: 1959-02-11
-- OK: 1966-10-10
-- NOT OK: 1972-05-23