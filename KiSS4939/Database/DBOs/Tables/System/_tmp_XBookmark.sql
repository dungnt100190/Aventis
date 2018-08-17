/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: 
  This table is used for #7877 to backup some bookmarks in release 4506.
  It can be deleted after this release!
=================================================================================================*/

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
SET ANSI_PADDING ON;
GO

-------------------------------------------------------------------------------
-- table structure
-------------------------------------------------------------------------------
CREATE TABLE [dbo].[_tmp_XBookmark](
	[XBookmarkID] [int] IDENTITY(1,1) NOT NULL,
	[BookmarkName] [varchar](200) NOT NULL,
	[SQL] [varchar](max) NOT NULL,
 CONSTRAINT [PK__tmp_XBookmark] PRIMARY KEY CLUSTERED 
(
	[XBookmarkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO
