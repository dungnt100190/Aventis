﻿CREATE TABLE [dbo].[XRule](
	[XRuleID] [int] NOT NULL,
	[RuleCode] [int] NOT NULL CONSTRAINT [DF_XRule_RuleCode]  DEFAULT ((3)),
	[RuleName] [varchar](200) NULL,
	[RuleDescription] [varchar](7000) NULL,
	[csCode] [text] NULL,
	[PublicRule] [bit] NOT NULL CONSTRAINT [DF_XRule_PublicRule]  DEFAULT ((0)),
	[TemplateRule] [bit] NOT NULL CONSTRAINT [DF_XRule_TemplateRule]  DEFAULT ((0)),
	[ModulID] [int] NULL,
	[DefaultSortKey] [int] NULL,
	[XRuleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XRule] PRIMARY KEY CLUSTERED 
(
	[XRuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[XRule]  WITH CHECK ADD  CONSTRAINT [FK_XRule_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO
ALTER TABLE [dbo].[XRule] CHECK CONSTRAINT [FK_XRule_XModul]