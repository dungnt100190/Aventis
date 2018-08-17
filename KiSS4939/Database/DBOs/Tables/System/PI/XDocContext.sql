CREATE TABLE [dbo].[XDocContext](
	[DocContextID] [int] IDENTITY(1,1) NOT NULL,
	[DocContextName] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[System] [bit] NOT NULL,
	[XDocContextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDocContext] PRIMARY KEY CLUSTERED 
(
	[DocContextID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_XDocContext] ON [dbo].[XDocContext] 
(
	[DocContextName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[XDocContext] ADD  CONSTRAINT [DF_XDocContext_System]  DEFAULT (0) FOR [System]
GO