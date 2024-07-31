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