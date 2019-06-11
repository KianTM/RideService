-- Checks if the database already exists before creating it. If it exists, the database is dropped, then created again. --
USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='RideService')
DROP DATABASE RideService

CREATE DATABASE RideService

USE RideService

-- Creates the tables for the database with all the proper names, values, properties and references. --
CREATE TABLE RideCategories (
	RideCategoryId int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(50) NOT NULL,
	Description nvarchar(MAX) NOT NULL
)

CREATE TABLE Rides (
	RideId int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(50) NOT NULL,
	Description nvarchar(MAX) NOT NULL,
	RideCategoryId int NOT NULL FOREIGN KEY REFERENCES RideCategories(RideCategoryId)
)

CREATE TABLE Reports (
	ReportId int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Status int NOT NULL,
	ReportTime datetime2(7) NOT NULL,
	Notes nvarchar(MAX),
	RideId int NOT NULL FOREIGN KEY REFERENCES Rides(RideId)
)

-- Click "Execute" at the top on your window or press F5 on your keyboard to create the database. --