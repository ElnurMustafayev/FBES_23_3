drop table Products

create table Products (
    [Id] int primary key identity,-- identity(5,2),
    [Name] nvarchar(50) not null unique,
    [Price] money not null check([Price] >= 0), -- check([Price] between 0 and 500),
    [Status] varchar(30) not null default 'in stock', -- unique,
    [ExpDate] datetime2,
)

insert into Products (Name, Price)
values ('IPhone 15', 1500)

select * from Products;