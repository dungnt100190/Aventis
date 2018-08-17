CREATE TABLE [kiss].[Dossier](
	[Id] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[ResponsibleDepartmentId] [uniqueidentifier] NOT NULL,
	[MainPersonZipCode] [varchar](11) NULL,
	[MainPersonSurname] [varchar](255) NOT NULL,
	[MainPersonAllianceName] [varchar](255) NULL,
	[MainPersonGivenName] [varchar](255) NOT NULL,
	[MainPersonDateOfBirth] [datetime] NULL,
	[MainPersonNativePlace] [varchar](255) NULL,
	[MainPersonMaritalState] [varchar](255) NULL,
	[MainPersonAhvNumber] [varchar](14) NULL,
	[MainPersonGender] [varchar](1) NULL,
	[MainPersonStreet] [varchar](255) NULL,
	[MainPersonPosteRestante] [varchar](255) NULL,
	[MainPersonZip] [varchar](40) NULL,
	[MainPersonCity] [varchar](255) NULL,
 CONSTRAINT [PK_Dossier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[Dossier]  WITH CHECK ADD  CONSTRAINT [FK_Dossier_Department] FOREIGN KEY([ResponsibleDepartmentId])
REFERENCES [kiss].[Department] ([Id])
GO

ALTER TABLE [kiss].[Dossier] CHECK CONSTRAINT [FK_Dossier_Department]
GO


