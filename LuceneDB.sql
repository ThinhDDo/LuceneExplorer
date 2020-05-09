create database LuceneDB
GO
use LuceneDB
GO
create table FileType (
TENTYPE varchar(20) primary key,
ISUSE bit not null default 0
)
GO
insert into FileType values ('json', 0)

