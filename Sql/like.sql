create table Products (
    [Id] int primary key identity,
    [Name] nvarchar(50) not null unique,
    [Price] money not null check([Price] >= 0), -- check([Price] between 0 and 500),
    [Status] varchar(30) null default 'in stock', -- unique,
    [ExpDate] datetime2 null,
)

insert into Products (Name, Price, Status)
values	('Test1', 111, 'stock stock'),
		('Test2', 222, 'stock'),
		('Test3', 333, 'stock in')


select * 
from Products
where [Status] = 'in stock' or [Status] = 'out of stock'

select * 
from Products
where [Status] in ('in stock', 'out of stock')

select Id, [Status]
from Products
where [Status] like '%st%ck%'

-- like 'stock%' - StartsWith
-- like '%stock' - EndsWith
-- like '%stock%' - Contains