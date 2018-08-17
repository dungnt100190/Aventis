CREATE TABLE [dbo].[BaWVCodeLOVEx](
	[BaWVCodeLOVExID] [int] NOT NULL,
	[WohnHeimatKanton] [varchar](1) NULL,
	[Hauptvorgang] [int] NULL,
	[Teilvorgang] [int] NULL,
	[BaWVCodeLOVExTS] [timestamp] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON