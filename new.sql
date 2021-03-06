USE [master]
GO
/****** Object:  Database [StudentsDb]    Script Date: 07.09.2020 23:14:25 ******/
CREATE DATABASE [StudentsDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Students', FILENAME = N'D:\learn\C#\EPAM\EPAM_Task6\EPAM_Task6\Students.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Students_log', FILENAME = N'D:\learn\C#\EPAM\EPAM_Task6\EPAM_Task6\Students.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentsDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentsDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentsDb] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [StudentsDb] SET ANSI_NULLS ON 
GO
ALTER DATABASE [StudentsDb] SET ANSI_PADDING ON 
GO
ALTER DATABASE [StudentsDb] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [StudentsDb] SET ARITHABORT ON 
GO
ALTER DATABASE [StudentsDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentsDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentsDb] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [StudentsDb] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [StudentsDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentsDb] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [StudentsDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentsDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentsDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentsDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentsDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentsDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentsDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentsDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentsDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentsDb] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentsDb] SET  MULTI_USER 
GO
ALTER DATABASE [StudentsDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentsDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentsDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentsDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentsDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentsDb] SET QUERY_STORE = OFF
GO
USE [StudentsDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [StudentsDb]
GO
/****** Object:  Table [dbo].[EducationalSubjects]    Script Date: 07.09.2020 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationalSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [int] NULL,
	[SubjectName] [nvarchar](max) NOT NULL,
	[SubjectType] [nvarchar](max) NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 07.09.2020 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 07.09.2020 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[SessionNumber] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentResults]    Script Date: 07.09.2020 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[EducationalSubjectSubjectId] [int] NULL,
	[Mark] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 07.09.2020 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[GroupId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EducationalSubjects] ON 

INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (1, 1, N'OOP', N'Exam', CAST(N'2020-05-09' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (3, 1, N'OAIP', N'Exam', CAST(N'2020-05-19' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (4, 1, N'Math', N'Credit', CAST(N'2020-05-06' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (5, 3, N'History', N'Exam', CAST(N'2020-05-15' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (6, 3, N'SUBD', N'Credit', CAST(N'2020-05-23' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (7, 3, N'TVIMS', N'Credit', CAST(N'2020-06-09' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (10, 3, N'SMAZAR', N'Credit', CAST(N'2020-06-11' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (11, 1002, N'Physics', N'Exam', CAST(N'2020-06-15' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (13, 1002, N'OOP', N'Exam', CAST(N'2020-06-19' AS Date))
INSERT [dbo].[EducationalSubjects] ([Id], [SessionId], [SubjectName], [SubjectType], [Date]) VALUES (14, 1003, N'MCHA', N'Exam', CAST(N'2020-06-24' AS Date))
SET IDENTITY_INSERT [dbo].[EducationalSubjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([Id], [Name]) VALUES (1, N'IP-32')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (2, N'IP-21')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (3, N'IP-31')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (4, N'ITP-12')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (5, N'ITI-22')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (6, N'ITP-21')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (7, N'IP-41')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (8, N'ITI-31')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (9, N'ITP32')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (10, N'IP-11')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (1011, N'IS-21')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (1012, N'IS-22')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (3011, N'IS-11')
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (3032, N'IS-12')
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (2, 1, 1)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (3, 1, 2)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (5, 1, 3)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (6, 1, 4)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (7, 2, 1)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (8, 2, 2)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (9, 2, 3)
INSERT [dbo].[Sessions] ([Id], [GroupId], [SessionNumber]) VALUES (10, 2, 4)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentResults] ON 

INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (3, 7, 1, N'8')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (5, 8, 3, N'9')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (6, 7, 3, N'6')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (7, 9, 4, N'7')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (8, 10, 5, N'10')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (9, 8, 1, N'4')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (10, 9, 1, N'2')
INSERT [dbo].[StudentResults] ([Id], [StudentId], [EducationalSubjectSubjectId], [Mark]) VALUES (11, 9, 6, N'5')
SET IDENTITY_INSERT [dbo].[StudentResults] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (7, N'Shyshkavets Pavel Sergeevich', N'Male', CAST(N'2000-05-09' AS Date), 1)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (8, N'Reita Match Sergeevna', N'Woman', CAST(N'2001-06-11' AS Date), 3)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (9, N'Artem Lukavtsov Gennadevich', N'Male', CAST(N'2000-02-13' AS Date), 2)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (10, N'Borisenko Ivan Sergeevich', N'Male', CAST(N'2002-08-19' AS Date), 3)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (11, N'Chaykov Andey Vasllyevich', N'Male', CAST(N'2003-03-03' AS Date), 1)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (12, N'Palatkin Daniil Aleksandrovich', N'Male', CAST(N'2000-09-21' AS Date), 4)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (13, N'Pankova Anastasiya Evgenevna', N'Woman', CAST(N'2001-01-01' AS Date), 4)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (14, N'Gruzdov Pavel Genadevich', N'Male', CAST(N'2002-03-26' AS Date), 5)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (15, N'Galavneva Ekaterina Genadevna', N'Woman', CAST(N'2000-06-19' AS Date), 6)
INSERT [dbo].[Students] ([Id], [FullName], [Gender], [DateOfBirth], [GroupId]) VALUES (16, N'Saykov Anatoliy Sergeevich', N'Male', CAST(N'2001-09-13' AS Date), 6)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
/****** Object:  Index [UQ__Sessions__3214EC0685B29304]    Script Date: 07.09.2020 23:14:25 ******/
ALTER TABLE [dbo].[Sessions] ADD UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__StudentR__3214EC06D413A8A4]    Script Date: 07.09.2020 23:14:25 ******/
ALTER TABLE [dbo].[StudentResults] ADD UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tmp_ms_x__32C52B980FDFB49B]    Script Date: 07.09.2020 23:14:25 ******/
ALTER TABLE [dbo].[Students] ADD UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EducationalSubjects]  WITH NOCHECK ADD  CONSTRAINT [FK_EducationalSubjectsList_To_Sessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[EducationalSubjects] CHECK CONSTRAINT [FK_EducationalSubjectsList_To_Sessions]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_GroupResults_To_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_GroupResults_To_Groups]
GO
ALTER TABLE [dbo].[StudentResults]  WITH CHECK ADD  CONSTRAINT [FK_StudentResults_To_EducationalSubjects] FOREIGN KEY([EducationalSubjectSubjectId])
REFERENCES [dbo].[EducationalSubjects] ([Id])
GO
ALTER TABLE [dbo].[StudentResults] CHECK CONSTRAINT [FK_StudentResults_To_EducationalSubjects]
GO
ALTER TABLE [dbo].[StudentResults]  WITH CHECK ADD  CONSTRAINT [FK_StudentResults_To_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[StudentResults] CHECK CONSTRAINT [FK_StudentResults_To_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Student_To_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Student_To_Groups]
GO
USE [master]
GO
ALTER DATABASE [StudentsDb] SET  READ_WRITE 
GO
