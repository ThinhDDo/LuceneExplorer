create database LuceneDB
GO
use LuceneDB
GO
create table FileType (
TENTYPE varchar(20) primary key,
ISUSE bit not null default 0
)
GO
create table Locations (
NAME varchar(255) primary key,
FULLPATH varchar(255) 
)

insert into Locations values ('Index', '')

select * from Locations