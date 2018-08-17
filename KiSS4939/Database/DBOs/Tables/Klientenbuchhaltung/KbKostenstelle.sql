CREATE TABLE [dbo].[KbKostenstelle](
  [KbKostenstelleID] [int] IDENTITY(1,1) NOT NULL,
  [Nr] [varchar](200) NULL,
  [Name] [varchar](200) NULL,
  [Vorsaldo] [money] NULL,
  [Aktiv] [bit] NOT NULL,
  [ModulID] [int] NULL,
  [KbKostenstelleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbKostenstelle] PRIMARY KEY CLUSTERED 
(
  [KbKostenstelleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KbKostenstelle_ModulID] ON [dbo].[KbKostenstelle] 
(
  [ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbKostenstelle Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbKostenstelle', @level2type=N'COLUMN',@level2name=N'KbKostenstelleID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vorsaldo aus einem Fremdsystem' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbKostenstelle', @level2type=N'COLUMN',@level2name=N'Vorsaldo'
GO

ALTER TABLE [dbo].[KbKostenstelle]  WITH CHECK ADD  CONSTRAINT [FK_KbKostenstelle_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[KbKostenstelle] CHECK CONSTRAINT [FK_KbKostenstelle_XModul]
GO