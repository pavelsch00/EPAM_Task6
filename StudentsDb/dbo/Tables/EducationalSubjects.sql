CREATE TABLE [dbo].[EducationalSubjects] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [SessionId]   INT            NULL,
    [SubjectName] NVARCHAR (MAX) NOT NULL,
    [SubjectType] NVARCHAR (MAX) NOT NULL,
    [Date]        DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EducationalSubjectsList_To_Sessions] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Sessions] ([Id]) ON DELETE SET NULL
)