CREATE TABLE [dbo].[Saves] (
    [Id]     INT           IDENTITY NOT NULL,
    [userId] INT           NOT NULL,
    [date]   DATETIME      DEFAULT (getdate()) NOT NULL,
    [state]  VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

