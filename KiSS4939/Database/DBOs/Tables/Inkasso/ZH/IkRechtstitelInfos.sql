CREATE TABLE [dbo].[IkRechtstitelInfos](
	[IkRechtstitelInfosID] [int] IDENTITY(1,1) NOT NULL,
	[IkRechtstitelID] [int] NOT NULL,
	[IkRechtstitelCode] [int] NULL,
	[RechtstitelInfo] [varchar](150) NULL,
	[RechtstitelDatumVon] [datetime] NULL,
	[RechtstitelRechtskraeftig] [datetime] NULL,
	[Teuerungseinsprache] [bit] NOT NULL CONSTRAINT [DF_IkRechtstitelInfos_Teuerungseinsprache]  DEFAULT ((0)),
	[IkRechtstitelInfoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkRechtstitelInfos] PRIMARY KEY CLUSTERED 
(
	[IkRechtstitelInfosID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_IkRechtstitelInfos_IkRechtstitelID]    Script Date: 11/23/2011 15:49:33 ******/
CREATE NONCLUSTERED INDEX [IX_IkRechtstitelInfos_IkRechtstitelID] ON [dbo].[IkRechtstitelInfos] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkRechtstitelInfos]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitelInfos_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IkRechtstitelInfos] CHECK CONSTRAINT [FK_IkRechtstitelInfos_IkRechtstitel]