CREATE TABLE [kiss].[Arrangement](
	[Id] [uniqueidentifier] NOT NULL,
	[ObsoleteIdentity] [int] NOT NULL,
	[DossierId] [uniqueidentifier] NOT NULL,
	[DossierNumber] [int] NOT NULL,
	[DateOfOrder] [datetime] NULL,
	[DateOfRepeal] [datetime] NULL,
	[ArrangementTypeName] [nvarchar](max) NULL,
	[ArrangementArticleName] [varchar](1000) NULL,
	[IsNewLaw] [bit] NOT NULL,
	[ArrangementNewLawId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Arrangement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[Arrangement]  WITH CHECK ADD  CONSTRAINT [FK_Arrangement_Dossier] FOREIGN KEY([DossierId])
REFERENCES [kiss].[Dossier] ([Id])
GO

ALTER TABLE [kiss].[Arrangement] CHECK CONSTRAINT [FK_Arrangement_Dossier]
GO

ALTER TABLE [kiss].[Arrangement] ADD  CONSTRAINT [DF_Arrangement_IsNewLaw]  DEFAULT ((1)) FOR [IsNewLaw]
GO

