CREATE TABLE [dbo].[KaBetriebBesprechung](
	[KaBetriebBesprechungID] [int] IDENTITY(1,1) NOT NULL,
	[KaBetriebID] [int] NULL,
	[Datum] [datetime] NULL,
	[KontaktGeplant] [datetime] NULL,
	[KontaktPersonID] [int] NULL,
	[AutorID] [int] NULL,
	[KontaktArtCode] [int] NULL,
	[Stichwort] [varchar](100) NULL,
	[Inhalt] [varchar](max) NULL,
	[KaBetriebBesprechungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaBetriebBesprechung] PRIMARY KEY CLUSTERED 
(
	[KaBetriebBesprechungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaBetriebBesprechung_KaBetriebID] ON [dbo].[KaBetriebBesprechung] 
(
	[KaBetriebID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaBetriebBesprechung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaBetriebBesprechung', @level2type=N'COLUMN',@level2name=N'KaBetriebBesprechungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaBetriebBesprechung_KaBetrieb) => KaBetrieb.KaBetriebID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaBetriebBesprechung', @level2type=N'COLUMN',@level2name=N'KaBetriebID'
GO

ALTER TABLE [dbo].[KaBetriebBesprechung]  WITH CHECK ADD  CONSTRAINT [FK_KaBetriebBesprechung_KaBetrieb] FOREIGN KEY([KaBetriebID])
REFERENCES [dbo].[KaBetrieb] ([KaBetriebID])
GO

ALTER TABLE [dbo].[KaBetriebBesprechung] CHECK CONSTRAINT [FK_KaBetriebBesprechung_KaBetrieb]
GO

ALTER TABLE [dbo].[KaBetriebBesprechung]  WITH CHECK ADD  CONSTRAINT [FK_KaBetriebBesprechung_XUser] FOREIGN KEY([AutorID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KaBetriebBesprechung] CHECK CONSTRAINT [FK_KaBetriebBesprechung_XUser]
GO