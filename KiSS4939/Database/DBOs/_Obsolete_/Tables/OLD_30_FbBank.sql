CREATE TABLE [dbo].[OLD_30_FbBank](
	[FbBankID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](70) NOT NULL,
	[Zusatz] [varchar](50) NULL,
	[Strasse] [varchar](50) NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[ClearingNr] [varchar](6) NULL,
	[PCKontoNr] [varchar](50) NULL,
	[GueltigAb] [datetime] NULL,
	[FbBankTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FBBANK] PRIMARY KEY NONCLUSTERED 
(
	[FbBankID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_FbBank] ON [dbo].[OLD_30_FbBank] 
(
	[Name] ASC
) ON [PRIMARY]
GO