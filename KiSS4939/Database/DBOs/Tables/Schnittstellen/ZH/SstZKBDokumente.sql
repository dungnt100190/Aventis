CREATE TABLE [dbo].[SstZKBDokumente](
	[SstZKBDokumenteID] [int] IDENTITY(1,1) NOT NULL,
	[ZKBPartnerNr] [varchar](20) NULL,
	[ZKBGeschaeftNr] [varchar](50) NULL,
	[ZKBFileName] [varchar](100) NULL,
	[Stichtag] [datetime] NULL,
	[ZKBDokumentTypCode] [int] NULL,
	[DocumentID] [int] NOT NULL,
	[SstZKBDokumenteTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstZKBDokumente] PRIMARY KEY CLUSTERED 
(
	[SstZKBDokumenteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON