SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetFallIconsOfPerson
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFaGetFallIconsOfPerson.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:29 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFaGetFallIconsOfPerson.sql $
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spFaGetFallIconsOfPerson
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFaGetFallIconsOfPerson
 (@DmgPersonID int)
AS BEGIN
  declare @OffActive   int
  declare @OffDisable  int
  declare @OffClosed   int
  declare @OffArchived int

  set @OffActive   = 0
  set @OffClosed   = 10
  set @OffArchived = 20
  set @OffDisable  = 30

  select B = 1,
         F = 2 +
               isNull((select top 1
                              case when FAL.DatumBis is null then @OffActive
                              else case when ARC.FaFallID is null then @OffClosed else @OffArchived end end
                       from   dbo.FaFall FAL WITH (READUNCOMMITTED) 
                              left join dbo.FaFallArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaFallID = FAL.FaFallID and
                                                            ARC.CheckOut is null
                       where  DmgPersonID = @DmgPersonID and
                              ModulCode = 2
                       order by case when FAL.DatumBis is null then 0 else 1 end, FAL.DatumVon desc,ARC.FaFallID desc),@OffDisable),

         S = 3 +
               isNull((select top 1
                              case when FAL.DatumBis is null then @OffActive
                              else case when ARC.FaFallID is null then @OffClosed else @OffArchived end end
                       from   dbo.FaFall FAL WITH (READUNCOMMITTED) 
                              left join dbo.FaFallArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaFallID = FAL.FaFallID and
                                                            ARC.CheckOut is null
                       where  DmgPersonID = @DmgPersonID and
                              ModulCode = 3
                       order by case when FAL.DatumBis is null then 0 else 1 end, FAL.DatumVon desc,ARC.FaFallID desc),@OffDisable),

         I = 4 +
               isNull((select top 1
                              case when FAL.DatumBis is null then @OffActive
                              else case when ARC.FaFallID is null then @OffClosed else @OffArchived end end
                       from   dbo.FaFall FAL WITH (READUNCOMMITTED) 
                              left join dbo.FaFallArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaFallID = FAL.FaFallID and
                                                       ARC.CheckOut is null
                       where  DmgPersonID = @DmgPersonID and
                              ModulCode = 4
                       order by case when FAL.DatumBis is null then 0 else 1 end, FAL.DatumVon desc,ARC.FaFallID desc),@OffDisable),

         V = 5 +
               isNull((select top 1
                              case when FAL.DatumBis is null then @OffActive
                              else case when ARC.FaFallID is null then @OffClosed else @OffArchived end end
                       from   dbo.FaFall FAL WITH (READUNCOMMITTED) 
                              left join dbo.FaFallArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaFallID = FAL.FaFallID and
                                                            ARC.CheckOut is null
                       where  DmgPersonID = @DmgPersonID and
                              ModulCode = 5
                       order by case when FAL.DatumBis is null then 0 else 1 end, FAL.DatumVon desc,ARC.FaFallID desc),@OffDisable),

         A = 6 +
               isNull((select top 1
                              case when FAL.DatumBis is null then @OffActive
                              else case when ARC.FaFallID is null then @OffClosed else @OffArchived end end
                       from   dbo.FaFall FAL WITH (READUNCOMMITTED) 
                              left join dbo.FaFallArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaFallID = FAL.FaFallID and
                                                     ARC.CheckOut is null
                       where  DmgPersonID = @DmgPersonID and
                              ModulCode = 6
                       order by case when FAL.DatumBis is null then 0 else 1 end, FAL.DatumVon desc,ARC.FaFallID desc),@OffDisable),

         K = 7 +
               isNull((select top 1
                              case when FAL.DatumBis is null then @OffActive
                              else case when ARC.FaFallID is null then @OffClosed else @OffArchived end end
                       from   dbo.FaFall FAL WITH (READUNCOMMITTED) 
                              left join dbo.FaFallArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaFallID = FAL.FaFallID and
                                                     ARC.CheckOut is null
                       where  DmgPersonID = @DmgPersonID and
                              ModulCode = 7
                       order by case when FAL.DatumBis is null then 0 else 1 end, FAL.DatumVon desc,ARC.FaFallID desc),@OffDisable)
END
GO