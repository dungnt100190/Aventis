CREATE TABLE [dbo].[OLD_30_DmgDossierMember](
	[DmgDossierMemberID] [int] IDENTITY(1,1) NOT NULL,
	[IdDossier] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[DossierMemberTypCode] [int] NOT NULL,
	[SortKey] [int] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[ImGleichenHaushalt] [bit] NULL,
	[IsUnterstuetzt] [bit] NULL,
	[Bemerkung] [text] NULL,
	[DmgDossierMemberTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_DmgDossierMember] PRIMARY KEY NONCLUSTERED 
(
	[DmgDossierMemberID] ASC
) ON [PRIMARY],
 CONSTRAINT [IX_DmgDossierMember] UNIQUE CLUSTERED 
(
	[IdDossier] ASC,
	[BaPersonID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE UNIQUE NONCLUSTERED INDEX [IXU_DmgDossierMember_DmgPersonID] ON [dbo].[OLD_30_DmgDossierMember] 
(
	[BaPersonID] ASC,
	[IdDossier] ASC,
	[DossierMemberTypCode] ASC
) ON [PRIMARY]
GO