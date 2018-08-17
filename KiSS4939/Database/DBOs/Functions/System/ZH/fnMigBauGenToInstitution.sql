SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnMigBauGenToInstitution
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnMigBauGenToInstitution
(
  @GENOSSENSCHAFT_ID int
)
RETURNS int
AS BEGIN
  RETURN CASE @GENOSSENSCHAFT_ID WHEN  1 THEN 502244
                                 WHEN  2 THEN 516010
                                 WHEN  3 THEN 508599
                                 WHEN  4 THEN 509098
                                 WHEN  5 THEN 511947
                                 WHEN  6 THEN 523215
                                 WHEN  7 THEN 504678
                                 WHEN  8 THEN 512266
                                 WHEN  9 THEN 524634
                                 WHEN 10 THEN 511043
                                 WHEN 11 THEN 523694
                                 WHEN 12 THEN 519942
                                 WHEN 13 THEN NULL
                                 WHEN 14 THEN 515960
                                 WHEN 15 THEN 515358
                                 WHEN 16 THEN 519485
                                 WHEN 17 THEN 525236
                                 WHEN 18 THEN 510537
                                 WHEN 19 THEN 515908
                                 WHEN 20 THEN 513143
                                 WHEN 21 THEN 522198
                                 WHEN 22 THEN 520533
                                 WHEN 23 THEN 511466
                                 WHEN 24 THEN 504756
                                 WHEN 25 THEN NULL
                                 WHEN 26 THEN 518969
                                 WHEN 27 THEN 516436
                                 WHEN 28 THEN 509966
                                 WHEN 29 THEN 508832
                                 WHEN 30 THEN 508728
                                 WHEN 31 THEN 521544
                                 WHEN 32 THEN 512447
                                 WHEN 33 THEN 555556
                                 WHEN 34 THEN 518312
                                 WHEN 35 THEN 520108
                                 WHEN 36 THEN 506419
                                 WHEN 37 THEN 504416
                                 WHEN 38 THEN 555322
                                 WHEN 39 THEN 524869
                                 WHEN 40 THEN 517712
                                 WHEN 41 THEN 523601
                                 WHEN 42 THEN NULL
                                 WHEN 43 THEN NULL
                                 WHEN 44 THEN 520689
                                 WHEN 45 THEN 523834
                                 WHEN 46 THEN NULL
                                 WHEN 47 THEN NULL
                                 WHEN 48 THEN 522025
                                 WHEN 49 THEN 515112
                                 WHEN 50 THEN NULL
                                 WHEN 51 THEN 508031
                                 WHEN 52 THEN NULL
                                 WHEN 53 THEN 516601
                                 WHEN 54 THEN NULL
                                 WHEN 55 THEN NULL
                                 WHEN 56 THEN 514600
                                 WHEN 57 THEN 511940
                                 WHEN 58 THEN 556586
                                 WHEN 59 THEN 505225
                                 WHEN 60 THEN 512129
                                 WHEN 62 THEN NULL
                                 WHEN 63 THEN 525121
                                 WHEN 64 THEN NULL
                                 WHEN 65 THEN NULL
                                 WHEN 66 THEN NULL
                                 WHEN 67 THEN 522443
                                 WHEN 68 THEN NULL
                                 WHEN 69 THEN 556363
                                 WHEN 70 THEN 507898
                                 WHEN 71 THEN 507489
                                 WHEN 72 THEN 510762
                                 WHEN 73 THEN NULL
                                 WHEN 74 THEN NULL
                                 WHEN 75 THEN NULL
                                 WHEN 76 THEN NULL
                                 WHEN 77 THEN NULL
                                 WHEN 78 THEN NULL--514948
                                 WHEN 79 THEN 555631
                                 WHEN 80 THEN 525062
                                 WHEN 81 THEN 509675
  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
