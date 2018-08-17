CREATE TABLE [dbo].[AmAbPosition](
	[AmAbPositionID] [int] IDENTITY(1,1) NOT NULL,
	[AmAnspruchsberechnungID] [int] NOT NULL,
	[AmAbPositionsartID] [int] NOT NULL,
	[AmAbKindID] [int] NULL,
	[ParentID] [int] NULL,
	[Text] [varchar](200) NULL,
	[DatumVon] [datetime] NULL,
	[Sortierung1] [varchar](2) NULL,
	[Sortierung2] [varchar](50) NULL,
	[Wert1] [money] NULL,
	[Mengeneinheit1] [varchar](50) NULL,
	[Format1] [varchar](20) NULL,
	[Wert2] [money] NULL,
	[Mengeneinheit2] [varchar](50) NULL,
	[Format2] [varchar](20) NULL,
	[Wert3] [money] NULL,
	[Bemerkung] [text] NULL,
	[AmAbPositionTS] [timestamp] NULL,
 CONSTRAINT [PK_AmAbPosition] PRIMARY KEY CLUSTERED 
(
	[AmAbPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_AmAbPosition_AmAnspruchsberechnungsID]    Script Date: 11/23/2011 10:31:37 ******/
CREATE NONCLUSTERED INDEX [IX_AmAbPosition_AmAnspruchsberechnungsID] ON [dbo].[AmAbPosition] 
(
	[AmAnspruchsberechnungID] ASC,
	[AmAbPositionsartID] ASC,
	[AmAbKindID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[AmAbPosition]  WITH CHECK ADD  CONSTRAINT [FK_AmAbPosition_AmAbKind] FOREIGN KEY([AmAbKindID])
REFERENCES [dbo].[AmAbKind] ([AmAbKindID])
GO
ALTER TABLE [dbo].[AmAbPosition] CHECK CONSTRAINT [FK_AmAbPosition_AmAbKind]
GO
ALTER TABLE [dbo].[AmAbPosition]  WITH CHECK ADD  CONSTRAINT [FK_AmAbPosition_AmAbPositionsart] FOREIGN KEY([AmAbPositionsartID])
REFERENCES [dbo].[AmAbPositionsart] ([AmAbPositionsartID])
GO
ALTER TABLE [dbo].[AmAbPosition] CHECK CONSTRAINT [FK_AmAbPosition_AmAbPositionsart]
GO
ALTER TABLE [dbo].[AmAbPosition]  WITH CHECK ADD  CONSTRAINT [FK_AmAbPosition_AmAnspruchsberechnung] FOREIGN KEY([AmAnspruchsberechnungID])
REFERENCES [dbo].[AmAnspruchsberechnung] ([AmAnspruchsberechnungID])
GO
ALTER TABLE [dbo].[AmAbPosition] CHECK CONSTRAINT [FK_AmAbPosition_AmAnspruchsberechnung]