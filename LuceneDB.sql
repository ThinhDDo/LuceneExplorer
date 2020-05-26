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
FULLPATH varchar(255) primary key
)
GO
create table ExcludedLocations (
EXCLUDEDPATH varchar(255) primary key,
PARENT varchar(255) not null,
FOREIGN KEY(PARENT) REFERENCES Locations(FULLPATH) on update cascade on delete cascade
)

DROP TABLE LOCATIONS 
GO
DROP TABLE ExcludedLocations

