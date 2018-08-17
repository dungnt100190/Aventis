CREATE TABLE [dbo].[PscdAusgleichLeiche](
	[PscdAusgleichLeicheID] [int] IDENTITY(1,1) NOT NULL,
	[AUGBL] [varchar](50) NULL,
	[AUGBT] [money] NULL,
	[AUGDT] [varchar](50) NULL,
	[AUGRD] [varchar](50) NULL,
	[EZDAT] [varchar](50) NULL,
	[OPBEL] [varchar](50) NULL,
	[VTREF] [varchar](50) NULL,
	[GPART] [varchar](50) NULL,
	[KEYZ1] [varchar](50) NULL,
	[OPUPK] [varchar](50) NULL,
	[OPUPW] [varchar](50) NULL,
	[OPUPZ] [varchar](50) NULL,
	[POSZA] [varchar](50) NULL,
	[WVSTAT] [varchar](50) NULL,
	[ErstelltDatum] [datetime] NOT NULL CONSTRAINT [DF_PscdAusgleichLeiche_ErstelltDatum]  DEFAULT (getdate()),
	[Fehlermeldung] [varchar](300) NULL,
 CONSTRAINT [PK_PscdAusgleichLeiche] PRIMARY KEY CLUSTERED 
(
	[PscdAusgleichLeicheID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO
SET ANSI_PADDING ON