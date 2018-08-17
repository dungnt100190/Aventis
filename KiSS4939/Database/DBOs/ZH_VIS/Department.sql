CREATE TABLE [kiss].[Department](
	[Id] [uniqueidentifier] NOT NULL,
	[DepartmentName] [varchar](255) NOT NULL,
	[DepartmentShortCut] [varchar](50) NOT NULL,
	[OrphanConcilGivenname] [varchar](255) NOT NULL,
	[OrphanConcilSurname] [varchar](255) NOT NULL,
	[OrphanConcilPhoneExternal] [varchar](20) NULL,
	[GenderValue] [smallint] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


