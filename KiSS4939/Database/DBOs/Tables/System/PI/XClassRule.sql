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
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_XClassRule] ON [dbo].[XClassRule] 
(
	[ClassName] ASC,
	[ControlName] ASC,
	[ComponentName] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XClass] FOREIGN KEY([ClassName])
REFERENCES [XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XClassRule] CHECK CONSTRAINT [FK_XClassRule_XClass]
GO

ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XClassComponent] FOREIGN KEY([ClassName], [ComponentName])
REFERENCES [XClassComponent] ([ClassName], [ComponentName])
GO

ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XClassControl] FOREIGN KEY([ClassName], [ControlName])
REFERENCES [XClassControl] ([ClassName], [ControlName])
GO

ALTER TABLE [dbo].[XClassRule] CHECK CONSTRAINT [FK_XClassRule_XClassControl]
GO

ALTER TABLE [dbo].[XClassRule]  WITH CHECK ADD  CONSTRAINT [FK_XClassRule_XRule] FOREIGN KEY([XRuleID])
REFERENCES [XRule] ([XRuleID])
ON UPDATE CASCADE
GO