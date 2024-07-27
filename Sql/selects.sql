create database MyDatabase

use MyDatabase

create table Products (
    [Name] nvarchar(max) not null,
    [Price] money not null,
    [Status] varchar(30),
    [ExpDate] datetime2,
)

-- Status:
-- null
-- sold out
-- in stock
-- bestseller
-- product of the day

select * from Products
select 'test' from Products
select 5 + 5 from Products
select len([Name]) from Products
select [Price] * 100 from Products
select [Price] * [Price] from Products
select [Price] * len([Name]) from Products

select top 5 ([Name] + ': ' + [Status]) as 'MyColumn'
from Products

select top 5 10 as 'Number' from Products

select top 10 len([Name]) as 'Length of name' from Products


select *
from Products
where Name = 'Rifampin'


select *
from Products
where Price > 19500


select [Name], [Price]
from Products
where Price >= 5000 and Price <= 6000


select [Name], [Price]
from Products
where Price between 5000 and 6000


select *
from Products
where ExpDate between '2025-05-01' and '2025-05-31'


select top 100 *
from Products
where Price > 19900


insert into Products (Name, Price, Status, ExpDate)
values (N'Телевизор', 30000, N'sold out', '2024-10-11 12:12:12')

select *
from Products
where Name = N'Телевизор'

select 'Тест'
select N'Тест😂'
select N'Test'


-- Проданные продукты, у которых цена была между 1000 и 5000
select *
from Products
where (Price between 1000 and 5000) and (Status = 'sold out')