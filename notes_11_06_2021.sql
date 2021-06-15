create database BooksDb
go

use BooksDb

--Books -BookId ,Title, AuthorId,Price
--Author -AuthorId,AuthorName

create table tbl_author
(
AuthorID int identity(1,1),
AuthorName Varchar(30)
Constraint Pk_auth primary key (AuthorID)
)

create table tbl_Books
(
BookId int identity(1000,1),
Title Varchar(50),
AuthorID int,
Price money,
constraint PK_book primary key(BookId),
constraint FK_auth Foreign key(AuthorID) 
references tbl_Author(AuthorID)
)
select * from tbl_author
select * from tbl_Books
insert into tbl_Books values('The Casual Vacancy',3,390)


DELETE FROM tbl_Books WHERE BookId=10;


create proc sp_InsertBook
@Title varchar(30),
@AuthorID int,
@Price money
as 
begin
insert  tbl_Books
(Title,AuthorID,Price)
values(@Title,@AuthorID,@price)
end

exec sp_InsertBook 'Angles & Demans',7,550

select * from tbl_Books
select * from tbl_author

create proc sp_UpdateBook
@BookId int,
@Title varchar(30),
@AuthorID int,
@Price money
as 
begin
Update tbl_Books set Title=@Title,AuthorId=@AuthorID,Price=@Price where BookId=@BookId
end

exec sp_UpdateBook 1003,'Desception Point',7,5000

select * from tbl_Books

create proc sp_UpdateAuthor
@AuthorId int,
@AuthorName varchar(30)
as 
begin
Update tbl_author set AuthorName=@AuthorName where AuthorId=@AuthorID
end
select * from tbl_author
exec sp_UpdateAuthor 1,'CHETAN BHAGAT'


create proc sp_InsertAuthor
@AuthorName varchar(30)
as 
begin
insert  tbl_author
(AuthorName)
values(@AuthorName)
end

exec sp_InsertAuthor 'Balakumaran'
select * from tbl_author



create proc sp_DeleteAuthor
@AuthorID int
as 
begin
Delete from tbl_author where AuthorID=@AuthorId
end

exec sp_DeleteAuthor 9

create proc sp_DeleteBook
@BookID int
as 
begin
Delete from tbl_Books where BookID=@BookId
end
select * from tbl_Books

exec sp_DeleteBook 1021