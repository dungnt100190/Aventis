CREATE TABLE [kiss].[Mandate](
	[Id] [uniqueidentifier] NOT NULL,
	[ArrangementId] [uniqueidentifier] NOT NULL,
	[DossierNumber] [int] NOT NULL,
	[ArrangementObsoleteIdentity] [int] NULL,
	[DateOfNomination] [datetime] NULL,
	[DateOfDismissal] [datetime] NULL,
	[MandateOfficerGivenname] [varchar](255) NOT NULL,
	[MandateOfficerSurname] [varchar](255) NOT NULL,
	[MandateOfficerCategory] [varchar](255) NOT NULL,
	[OrtsCode] [varchar](2) NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[PersonNumber] [int] NOT NULL,
 CONSTRAINT [PK_Mandate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[Mandate]  WITH CHECK ADD  CONSTRAINT [FK_Mandate_Arrangement] FOREIGN KEY([ArrangementId])
REFERENCES [kiss].[Arrangement] ([Id])
GO

ALTER TABLE [kiss].[Mandate] CHECK CONSTRAINT [FK_Mandate_Arrangement]
GO


