CREATE TABLE [dbo].[XClassRule](
	[XClassRuleID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](255) NOT NULL,
	[ControlName] [varchar](255) NULL,
	[ComponentName] [varchar](255) NULL,
	[XRuleID] [int] NOT NULL,
	[SortKey] [int] NOT NULL CONSTRAINT [DF_XClassRule_SortOrder]  DEFAULT ((100)),
	[Active] [bit] NOT NULL CONSTRAINT [DF_XClassRule_Active]  DEFAULT ((1)),
	[XClassRuleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassRule] PRIMARY KEY NONCLUSTERED 
(
	[XClassRuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XClassRule]    Script Date: 11/23/2011 16:46:28 ******/
CREATE CLUSTERED INDEX [IX_XClassRule] ON [dbo].[XClassRule] 
(
	[ClassName] ASC,
	[ControlName] ASC,
	[ComponentName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
GO
ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[XClassRule] CHECK CONSTRAINT [FK_XClassRule_XClass]
GO
ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XClassComponent] FOREIGN KEY([ClassName], [ComponentName])
REFERENCES [dbo].[XClassComponent] ([ClassName], [ComponentName])
GO
ALTER TABLE [dbo].[XClassRule] CHECK CONSTRAINT [FK_XClassRule_XClassComponent]
GO
ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XClassControl] FOREIGN KEY([ClassName], [ControlName])
REFERENCES [dbo].[XClassControl] ([ClassName], [ControlName])
GO
ALTER TABLE [dbo].[XClassRule] CHECK CONSTRAINT [FK_XClassRule_XClassControl]
GO
ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XRule] FOREIGN KEY([XRuleID])
REFERENCES [dbo].[XRule] ([XRuleID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[XClassRule] CHECK CONSTRAINT [FK_XClassRule_XRule]