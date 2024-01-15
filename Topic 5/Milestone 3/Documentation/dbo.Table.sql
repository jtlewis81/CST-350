CREATE TABLE [dbo].[Users]
(
	[ID] INT IDENTITY(1,1) NOT NULL,
	[FIRSTNAME] varchar (20) NOT NULL,
	[LASTNAME] varchar (20) NOT NULL,
	[SEX] varchar (1) NOT NULL,
	[AGE] int NOT NULL,
	[STATE] varchar (2) NOT NULL,
	[EMAIL] varchar (40) NOT NULL,
	[USERNAME] varchar (40) NOT NULL,
	[PASSWORD] varchar (40) NOT NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC)
)
