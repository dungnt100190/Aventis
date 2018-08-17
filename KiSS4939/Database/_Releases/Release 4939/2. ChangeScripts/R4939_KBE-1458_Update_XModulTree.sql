/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to add Kes-Massnahmeführung to Modul V
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

DECLARE @NewModulID INT,
        @NewModulID_Parent INT,
        @NewSortkey INT;
SELECT  @NewModulID = 5,
        @NewModulID_Parent = 50000,
        @NewSortkey = 2;

-------------------------------------------------------------------------------
-- Step 1: Make sure, there is a gap in the list of child-masks (increment SortKey on every mask after the position where the new mask is placed)
-------------------------------------------------------------------------------
UPDATE XModulTree SET SortKey = SortKey + 1 WHERE ModulID = @NewModulID AND ModulTreeID_Parent = @NewModulID_Parent and SortKey >= @NewSortkey;

-------------------------------------------------------------------------------
-- Step 2: Insert mask in XModulTree
-------------------------------------------------------------------------------
INSERT INTO XModulTree (ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, ModulTreeCode, sqlInsertTreeItem, Active)
VALUES (52900,				--ModulTreeID
        @NewModulID_Parent, --ModulTreeID_Parent
        @NewModulID,		--ModulID
        @NewSortkey,		--SortKey
        0,					--XIconID
        'Massnahmenführung', --Name
        'Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View', --ClassName
        1,	   --ModulTreeCode
        'UPDATE #Tree    SET Zusatz = NULL,        
                         IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                                            FROM dbo.KesMassnahme KMA WITH (READUNCOMMITTED)                                             
                                                              INNER JOIN #Tree    TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = KMA.FaLeistungID
                                                            WHERE KMA.IsDeleted = 0
                                                            UNION ALL                                                                                      
                                                            SELECT TOP 1 1                                           
                                                            FROM dbo.KesDokument KDO WITH (READUNCOMMITTED)                                             
                                                              INNER JOIN  #Tree  TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = KDO.FaLeistungID
                                                            WHERE KDO.IsDeleted = 0)
                                                    THEN 5062                              
                                               ELSE 5063                         
                                          END)  
        WHERE ModulTreeID = @ModulTreeID',    --sqlInsertTreeItem
        1);    --Active



GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

