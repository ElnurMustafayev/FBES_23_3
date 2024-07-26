print 'test'

create database MyDatabase
use MyDatabase

-- use master
-- drop database MyDatabase

create table MyTable (
	MyIntColumn int,
	MyFloatColumn float
)

-- drop table MyTable

-- char(n)				(|abcde     |)
-- nchar(n)				(|рст       |)
-- varchar(n)			(|abcde|     )
-- nvarchar(n)			(|рст|       )

-- n - limit

create table Users (
	[Name] varchar(50),
	[Surname] varchar(50),
	[Gender] bit,
	[Birthdate] datetime2
)