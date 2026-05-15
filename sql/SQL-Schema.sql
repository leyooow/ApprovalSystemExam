-- Create Database
CREATE DATABASE ApprovalSystemDB;
GO

-- Use Database
USE ApprovalSystemDB;
GO

-- Create Table
CREATE TABLE Requests (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(2000) NOT NULL,
    RequestedBy NVARCHAR(100) NOT NULL,
    Status INT NOT NULL,
    ReviewedBy NVARCHAR(100) NULL,
    Remarks NVARCHAR(500) NULL,
    DateCreated DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    DateReviewed DATETIME2 NULL
);
GO