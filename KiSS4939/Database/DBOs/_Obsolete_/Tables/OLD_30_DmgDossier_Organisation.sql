CREATE TABLE [dbo].[OLD_30_DmgDossier_Organisation](
	[DmgDossier_OrganisationID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NULL,
	[IdDossier] [int] NULL,
	[BaInstitutionID] [int] NOT NULL,
	[Bemerkung] [text] NULL,
	[DmgDossier_OrganisationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_DmgDossier_Organisation] PRIMARY KEY CLUSTERED 
(
	[DmgDossier_OrganisationID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_DmgDossier_Organisation_DmgPersonID] ON [dbo].[OLD_30_DmgDossier_Organisation] 
(
	[BaPersonID] ASC,
	[BaInstitutionID] ASC
) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_DmgDossier_Organisation_IdDossier] ON [dbo].[OLD_30_DmgDossier_Organisation] 
(
	[IdDossier] ASC,
	[BaInstitutionID] ASC
) ON [PRIMARY]
GO