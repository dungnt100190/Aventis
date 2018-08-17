CREATE TABLE [dbo].[XRule](
	[XRuleID] [int] NOT NULL,
	[RuleCode] [int] NOT NULL,
	[RuleName] [varchar](200) NULL,
	[RuleDescription] [varchar](7000) NULL,
	[csCode] [varchar](max) NULL,
	[PublicRule] [bit] NOT NULL,
	[TemplateRule] [bit] NOT NULL,
	[ModulID] [int] NULL,
	[DefaultSortKey] [int] NULL,
	[XRuleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XRule] PRIMARY KEY CLUSTERED 
(
	[XRuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XRule Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRule', @level2type=N'COLUMN',@level2name=N'XRuleID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XRule_XModul) => XModul.ModulID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XRule', @level2type=N'COLUMN',@level2name=N'ModulID'
GO

ALTER TABLE [dbo].[XRule]  WITH CHECK ADD  CONSTRAINT [FK_XRule_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XRule] CHECK CONSTRAINT [FK_XRule_XModul]
GO

ALTER TABLE [dbo].[XRule] ADD  CONSTRAINT [DF_XRule_RuleCode]  DEFAULT ((3)) FOR [RuleCode]
GO

ALTER TABLE [dbo].[XRule] ADD  CONSTRAINT [DF_XRule_PublicRule]  DEFAULT ((0)) FOR [PublicRule]
GO

ALTER TABLE [dbo].[XRule] ADD  CONSTRAINT [DF_XRule_TemplateRule]  DEFAULT ((0)) FOR [TemplateRule]
GO