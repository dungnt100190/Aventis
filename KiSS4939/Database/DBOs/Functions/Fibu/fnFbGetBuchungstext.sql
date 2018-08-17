SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnFbGetBuchungstext
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnFbGetBuchungstext.sql $Author: $
  $Modtime: 3.02.10 10:27 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnFbGetBuchungstext.sql $
 * 
 * 2     3.02.10 10:29 Nweber
 * Anpassung vom Thomas einchecken
 * 
 * 1     18.12.09 8:34 Ckaeser


=================================================================================================*/
CREATE FUNCTION dbo.fnFbGetBuchungstext
 (@Buchungstext  varchar(2000),
  @Datum         datetime)
 RETURNS varchar(2000)
AS BEGIN
/*
   Replaces specific strings of @Buchungstext with values depending on @Datum
   Replace-strings: {Jahr}
                    {Monat}
                    {MonatText}
                    {MonatKurzText}
                    {Tag}
   all replace-strings can be used with an offset: '+(-)<int>' ex.: {Jahr+5} {Monat+-5}
*/
  DECLARE @start  int,
          @END    int,
          @offset int

-------
--- Jahr 
-------
  -- Jahr ohne Offset
  SELECT @Buchungstext = replace (@Buchungstext, '{Jahr}' , DatePart(Year, @Datum))
  -- Jahr mit Offset
  WHILE (charindex('{Jahr+', @Buchungstext) > 0) BEGIN
     SELECT @start  = charindex('{Jahr+', @Buchungstext)
     SELECT @END    = charindex('}', @Buchungstext,  @start)+1
     SELECT @offset = SubString(@Buchungstext , @start+6 , @END-@start-7 )
     SELECT @Buchungstext = replace(@Buchungstext, SubString(@Buchungstext , @start , @END - @start), DatePart(Year, @Datum) + @offset)
  END

-------
--- Monat 
-------
  -- Monat ohne Offset
  SELECT @Buchungstext = replace (@Buchungstext, '{Monat}' , DatePart(month, @Datum))
  -- Jahr mit Offset
  WHILE (charindex('{Monat+', @Buchungstext) > 0) BEGIN
     SELECT @start  = charindex('{Monat+', @Buchungstext)
     SELECT @END    = charindex('}', @Buchungstext,  @start)+1
     SELECT @offset = SubString(@Buchungstext , @start+7 , @END-@start-8 )
     SELECT @Buchungstext = replace(@Buchungstext, SubString(@Buchungstext , @start , @END - @start), DatePart(month, DateAdd(month, @offset, @Datum)))
  END

-------
--- Monat-Text
-------
  -- Monat-Text ohne Offset
  SELECT @Buchungstext = replace (@Buchungstext, '{MonatText}' , dbo.fnXMonat(DatePart(month, @Datum)))
  -- Jahr mit Offset
  WHILE (charindex('{MonatText+', @Buchungstext) > 0) BEGIN
     SELECT @start  = charindex('{MonatText+', @Buchungstext)
     SELECT @END    = charindex('}', @Buchungstext,  @start)+1
     SELECT @offset = SubString(@Buchungstext , @start+11 , @END-@start-12 )
     SELECT @Buchungstext = replace(@Buchungstext, SubString(@Buchungstext , @start , @END - @start), dbo.fnXMonat(DatePart(month, DateAdd(month, @offset, @Datum))))
  END

-------
--- KurzMonat-Text
-------
  -- Monat-Text ohne Offset
  SELECT @Buchungstext = replace (@Buchungstext, '{MonatKurzText}' , dbo.fnXKurzMonat(DatePart(month, @Datum)))
  -- Jahr mit Offset
  WHILE (charindex('{MonatKurzText+', @Buchungstext) > 0) BEGIN
     SELECT @start  = charindex('{MonatKurzText+', @Buchungstext)
     SELECT @END    = charindex('}', @Buchungstext,  @start)+1
     SELECT @offset = SubString(@Buchungstext , @start+15 , @END-@start-16 )
     SELECT @Buchungstext = replace(@Buchungstext, SubString(@Buchungstext , @start , @END - @start), dbo.fnXKurzMonat(DatePart(month, DateAdd(month, @offset, @Datum))))
  END

-------
--- Tag
-------
  -- Tag ohne Offset
  SELECT @Buchungstext = replace (@Buchungstext, '{Tag}' , DatePart(day, @Datum))
  -- Tag mit Offset
  WHILE (charindex('{Tag+', @Buchungstext) > 0) BEGIN
     SELECT @start  = charindex('{Tag+', @Buchungstext)
     SELECT @END    = charindex('}', @Buchungstext,  @start)+1
     SELECT @offset = SubString(@Buchungstext , @start+5 , @END-@start-6 )
     SELECT @Buchungstext = replace(@Buchungstext, SubString(@Buchungstext , @start , @END - @start), DatePart(day, dateadd(day,@offset,@Datum)))
  END

  RETURN ( @Buchungstext )
END
