CREATE DATABASE SmartWicket;
GO

USE [SmartWicket]
GO
/****** Object:  Table [dbo].[Visitors]    Script Date: 30.10.2017 12:06:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitors](
	[Id] [uniqueidentifier] NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Sex] [bit] NOT NULL,
 CONSTRAINT [PK_Visitors_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visits]    Script Date: 30.10.2017 12:06:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[Id] [uniqueidentifier] NOT NULL,
	[VisitorId] [uniqueidentifier] NOT NULL,
	[VisitDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Visits_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Visitors] ([Id], [LastName], [FirstName], [BirthDate], [Sex]) VALUES (N'd807ef6b-15bd-463d-b97e-a6ffcf92a480', N'Ivanov', N'Ivan', CAST(0x8E170B00 AS Date), 0)
GO
INSERT [dbo].[Visits] ([Id], [VisitorId], [VisitDate], [CreatedDate]) VALUES (N'c438dc9e-f4ab-48c5-ab95-a13497281936', N'd807ef6b-15bd-463d-b97e-a6ffcf92a480', CAST(0x0000A81B00FE3B36 AS DateTime), CAST(0x0000A81B00FE3B37 AS DateTime))
GO
INSERT [dbo].[Visits] ([Id], [VisitorId], [VisitDate], [CreatedDate]) VALUES (N'210523aa-ba60-4045-9842-d5d4b397bf09', N'd807ef6b-15bd-463d-b97e-a6ffcf92a480', CAST(0x0000A81B00B8595E AS DateTime), CAST(0x0000A81B00FE3B36 AS DateTime))
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_VisitorId] FOREIGN KEY([VisitorId])
REFERENCES [dbo].[Visitors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_VisitorId]
GO
