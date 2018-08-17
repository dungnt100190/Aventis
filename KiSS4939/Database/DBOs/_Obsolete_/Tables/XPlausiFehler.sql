CREATE TABLE [dbo].[XPlausiFehler](
	[XPlausiFehlerID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[PlausiNo] [int] NOT NULL,
	[VarName] [varchar](50) NULL,
	[Text] [varchar](255) NOT NULL,
	[PlausiFehlerTypCode] [int] NULL CONSTRAINT [DF_XPlausiFehler_PlausiFehlerTypCode]  DEFAULT ((0)),
	[Erledigt] [bit] NOT NULL CONSTRAINT [DF_XPlausiFehler_Erledigt]  DEFAULT ((0)),
	[XPlausiFehlerTS] [timestamp] NOT NULL,
	[DossierID] [int] NULL,
 CONSTRAINT [PK_XPlausiFehler] PRIMARY KEY NONCLUSTERED 
(
	[XPlausiFehlerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XPlausiFehler]    Script Date: 11/23/2011 16:57:48 ******/
CREATE CLUSTERED INDEX [IX_XPlausiFehler] ON [dbo].[XPlausiFehler] 
(
	[BaPersonID] ASC,
	[PlausiFehlerTypCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]