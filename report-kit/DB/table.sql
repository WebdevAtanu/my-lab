CREATE TABLE [streamlit-dashboard].dbo.Payments (
	PaymentId uniqueidentifier NULL,
	UserId uniqueidentifier NULL,
	PaidAmount decimal(18,2) NULL,
	PaymentDate date NULL
);

CREATE TABLE [streamlit-dashboard].dbo.Users (
	UserId uniqueidentifier NULL,
	UserName varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Age int NULL
);