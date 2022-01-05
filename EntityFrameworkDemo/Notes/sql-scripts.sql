create database Learning_Db;
--------------------------------------

create table Students (ID int primary key identity(1,1),
FirstName varchar(30),
LastName varchar(30),
EnrollmentDate DateTime
);
