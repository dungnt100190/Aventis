CREATE TABLE [dbo].[MigLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Function] [varchar](100) NULL,
	[Table] [varchar](100) NULL,
	[Column] [varchar](100) NULL,
	[Time] [varchar](30) NULL,
	[Rows] [int] NULL,
	[Duration_ms] [int] NULL,
	[Prms] [varchar](200) NULL,
	[Error] [varchar](1000) NULL,
	[MigLogTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_MigLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLog', @level2type=N'COLUMN',@level2name=N'MigLogTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLog'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Logtabelle für Datenanonymisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLog'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Anonymisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MigLog'
GO

