CREATE TABLE [dbo].[XMenuItem](
	[MenuItemID] [int] IDENTITY(1,1) NOT NULL,
	[ParentMenuItemID] [int] NULL,
	[ClassName] [varchar](255) NULL,
	[ControlName] [varchar](255) NULL,
	[BeginMenuGroup] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[OnlyBIAGAdminVisible] [bit] NOT NULL,
	[Caption] [varchar](100) NOT NULL,
	[MenuTID] [int] NULL,
	[ItemShortcutCtrl] [bit] NOT NULL,
	[ItemShortcutShift] [bit] NOT NULL,
	[ItemShortcutAlt] [bit] NOT NULL,
	[ItemShortcutKey] [varchar](50) NULL,
	[ImageIndex] [int] NOT NULL,
	[ImageIndexDisabled] [int] NOT NULL,
	[SortKey] [int] NULL,
	[ShowInToolbar] [bit] NOT NULL,
	[BeginToolbarGroup] [bit] NOT NULL,
	[ToolbarSortKey] [int] NULL,
	[System] [bit] NOT NULL,
	[HideLockedItems] [bit] NOT NULL,
	[Description] [text] NULL,
	[XMenuItemTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XMenuItem] PRIMARY KEY CLUSTERED 
(
	[MenuItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_XMenuItem] ON [dbo].[XMenuItem] 
(
	[ParentMenuItemID] ASC,
	[SortKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Menu-Eintrag nur für BIAG Super-Administratoren sichtbar ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XMenuItem', @level2type=N'COLUMN',@level2name=N'OnlyBIAGAdminVisible'
GO

ALTER TABLE [dbo].[XMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_XMenuItem_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[XMenuItem] CHECK CONSTRAINT [FK_XMenuItem_XClass]
GO

ALTER TABLE [dbo].[XMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_XMenuItem_XMenuItem] FOREIGN KEY([ParentMenuItemID])
REFERENCES [dbo].[XMenuItem] ([MenuItemID])
GO

ALTER TABLE [dbo].[XMenuItem] CHECK CONSTRAINT [FK_XMenuItem_XMenuItem]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_BeginGroup]  DEFAULT ((0)) FOR [BeginMenuGroup]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_Visible]  DEFAULT ((1)) FOR [Visible]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_OnlyBIAGAdminVisible]  DEFAULT ((0)) FOR [OnlyBIAGAdminVisible]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_ItemShortcutCtrl]  DEFAULT ((0)) FOR [ItemShortcutCtrl]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_ItemShortcutShift]  DEFAULT ((0)) FOR [ItemShortcutShift]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_ItemShortcutAlt]  DEFAULT ((0)) FOR [ItemShortcutAlt]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_ImageIndex]  DEFAULT ((-1)) FOR [ImageIndex]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_ImageIndexDisabled]  DEFAULT ((-1)) FOR [ImageIndexDisabled]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_ShowInToolbar]  DEFAULT ((0)) FOR [ShowInToolbar]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_BeginToolbarGroup]  DEFAULT ((0)) FOR [BeginToolbarGroup]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_System]  DEFAULT ((0)) FOR [System]
GO

ALTER TABLE [dbo].[XMenuItem] ADD  CONSTRAINT [DF_XMenuItem_HideDisabledItems]  DEFAULT ((0)) FOR [HideLockedItems]
GO