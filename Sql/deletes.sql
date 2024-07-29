
create table Products (
    [Id] int primary key identity,
    [Name] nvarchar(50) not null unique,
    [Price] money not null check([Price] >= 0), -- check([Price] between 0 and 500),
    [Status] varchar(30) null default 'in stock', -- unique,
    [ExpDate] datetime2 null,
)

insert into Products (Name, Price, Status)
values	('Tv', 750, 'in stock'),
		('IPhone 14', 1000, 'out of stock'),
		('Book', 2, 'bestseller'),
		('Car', 30000, 'bestseller'),
		('Remote', 10, null),
		('IPhone 15', 1500, 'in stock')

-- drop
-- delete

--drop table Products
--delete Products

delete Products
where Id % 2 = 1


select * from Products