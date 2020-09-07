﻿CREATE TABLE [dbo].[StudentResults] (
    [Id]                          INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]                   INT            NULL,
    [EducationalSubjectSubjectId] INT            NULL,
    [Mark]                        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StudentResults_To_EducationalSubjects] FOREIGN KEY ([EducationalSubjectSubjectId]) REFERENCES [dbo].[EducationalSubjects] ([Id]),
    CONSTRAINT [FK_StudentResults_To_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE SET NULL
)