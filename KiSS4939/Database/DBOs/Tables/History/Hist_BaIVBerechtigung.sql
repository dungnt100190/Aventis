CREATE TABLE [dbo].[Hist_BaIVBerechtigung](
	[BaIVBerechtigungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[BaIVBerechtigungCode] [int] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BaIVBerechtigung] PRIMARY KEY CLUSTERED 
(
	[BaIVBerechtigungID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF 