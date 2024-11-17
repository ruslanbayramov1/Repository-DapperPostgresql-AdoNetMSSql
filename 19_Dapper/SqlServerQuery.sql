CREATE DATABASE DapperCrud
USE DapperCRUD

CREATE TABLE Students 
(
    Id int identity PRIMARY KEY,
    Name varchar(16) NOT NULL,
    Surname varchar(16) NOT NULL,
    GroupName varchar(26) NOT NULL
);