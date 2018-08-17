CREATE TABLE [dbo].[OLD_30_AiInkassoTypVsForderungTyp](
	[AiInkassoTypID] [int] NOT NULL,
	[AiForderungTypID] [int] NOT NULL,
	[AiInkassoTypVsForderungTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiInkassoTypVsForderungTyp] PRIMARY KEY CLUSTERED 
(
	[AiInkassoTypID] ASC,
	[AiForderungTypID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OLD_30_AiInkassoTypVsForderungTyp]  WITH CHECK ADD  CONSTRAINT [FK_tcoKissAiInkassoTypVsForderungTyp_tcoKissAiForderungTyp] FOREIGN KEY([AiForderungTypID])
REFERENCES [OLD_30_AiForderungTyp] ([AiForderungTypID])
GO

ALTER TABLE [dbo].[OLD_30_AiInkassoTypVsForderungTyp] CHECK CONSTRAINT [FK_tcoKissAiInkassoTypVsForderungTyp_tcoKissAiForderungTyp]
GO

ALTER TABLE [dbo].[OLD_30_AiInkassoTypVsForderungTyp]  WITH CHECK ADD  CONSTRAINT [FK_tcoKissAiInkassoTypVsForderungTyp_tcoKissAiInkassoTyp] FOREIGN KEY([AiInkassoTypID])
REFERENCES [OLD_30_AiInkassoTyp] ([AiInkassoTypID])
GO

ALTER TABLE [dbo].[OLD_30_AiInkassoTypVsForderungTyp] CHECK CONSTRAINT [FK_tcoKissAiInkassoTypVsForderungTyp_tcoKissAiInkassoTyp]
GO