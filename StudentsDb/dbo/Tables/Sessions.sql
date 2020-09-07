CREATE TABLE [dbo].[Sessions] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [GroupId]       INT NOT NULL,
    [SessionNumber] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GroupResults_To_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
    UNIQUE NONCLUSTERED ([Id] ASC)
);

