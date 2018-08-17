SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXConvertRTF2Text;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Converts the given RTF formatted text back to its plaintext. This function should be
           used just for migrations.
    @RTFText: The rtf text to convert to plaintext
  -
  RETURNS: The plaintext of the given RTF formatted text as good as possible
  -
  WARNING: This is not a 100% solution but better than nothing. If you find a tag that is not
           handlet properly, please correct the function.
=================================================================================================
  TEST:    SELECT dbo.fnXConvertRTF2Text('{\rtf1\ansi\ansicpg1252\deff0\deftab720{\fonttbl{\f0\fswiss MS Sans Serif;}{\f1\froman\fcharset2 Symbol;}{\f2\fswiss Tahoma;}}  {\colortbl\red0\green0\blue0;}  \deflang2055\horzdoc{\*\fchars }{\*\lchars }\pard\plain\f2\fs20 Betrifft: mehrere  \par   \par Mietanteil Herr Bajraktaraj Fr. 291.-- (1/6)  \par }    ');
=================================================================================================*/

CREATE FUNCTION dbo.fnXConvertRTF2Text
(
  @RTFText VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate first (performance)
  -----------------------------------------------------------------------------
  IF (@RTFText IS NULL OR @RTFText NOT LIKE '%{\rtf1%')
  BEGIN
    RETURN @RTFText;
  END;
  
  -----------------------------------------------------------------------------
  -- remove known rtf-tags with its proper non-rtf value
  -----------------------------------------------------------------------------
  -- format
  SET @RTFText = REPLACE(@RTFText, '{\rtf1', '');
  SET @RTFText = REPLACE(@RTFText, '{\fonttbl', '');
  SET @RTFText = REPLACE(@RTFText, '{\colortbl ;', '');
  SET @RTFText = REPLACE(@RTFText, '{\colortbl', '');
  SET @RTFText = REPLACE(@RTFText, '{\*\fchars }', '');
  SET @RTFText = REPLACE(@RTFText, '{\*\lchars }', '');
  SET @RTFText = REPLACE(@RTFText, '{\*\pn', '');
  SET @RTFText = REPLACE(@RTFText, '{\pntxtb', '');
  --
  SET @RTFText = REPLACE(@RTFText, '\deff0', '');
  SET @RTFText = REPLACE(@RTFText, '\deftab720', '');
  SET @RTFText = REPLACE(@RTFText, '\deflang1031', '');
  SET @RTFText = REPLACE(@RTFText, '\deflang2055', '');
  SET @RTFText = REPLACE(@RTFText, '\lang1031', '');
  SET @RTFText = REPLACE(@RTFText, '\lang2055', '');
  SET @RTFText = REPLACE(@RTFText, '\lang2057', '');
  SET @RTFText = REPLACE(@RTFText, '\ansicpg1252', '');
  SET @RTFText = REPLACE(@RTFText, '\ansi', '');
  SET @RTFText = REPLACE(@RTFText, '\horzdoc', '');
  SET @RTFText = REPLACE(@RTFText, '\viewkind4', '');
  SET @RTFText = REPLACE(@RTFText, '\uc1', '');
  SET @RTFText = REPLACE(@RTFText, '\plain', '');
  SET @RTFText = REPLACE(@RTFText, '\pard', '');
  SET @RTFText = REPLACE(@RTFText, '\colortbl ;', '');
  SET @RTFText = REPLACE(@RTFText, '\colortbl', '');
  SET @RTFText = REPLACE(@RTFText, '\fi-240', '');
  SET @RTFText = REPLACE(@RTFText, '\pnlvlblt', '');
  SET @RTFText = REPLACE(@RTFText, '\pntext', '');
  SET @RTFText = REPLACE(@RTFText, '\pnf3', '');
  SET @RTFText = REPLACE(@RTFText, '\keepn', '');
  SET @RTFText = REPLACE(@RTFText, '\sa100', '');
  SET @RTFText = REPLACE(@RTFText, '\sb100', '');
  SET @RTFText = REPLACE(@RTFText, '\ltrpar', '');
  SET @RTFText = REPLACE(@RTFText, '\protect', '');
  SET @RTFText = REPLACE(@RTFText, '\sl280', '');
  --
  SET @RTFText = REPLACE(@RTFText, '\b0', '');  -- bold end
  SET @RTFText = REPLACE(@RTFText, '\b', '');
  SET @RTFText = REPLACE(@RTFText, '\i0', '');  -- italic end
  SET @RTFText = REPLACE(@RTFText, '\i', '');
  SET @RTFText = REPLACE(@RTFText, '\u0', '');  -- underscore end
  SET @RTFText = REPLACE(@RTFText, '\u', '');
  --
  SET @RTFText = REPLACE(@RTFText, '}', '');
  
  -- tags
  SET @RTFText = REPLACE(@RTFText, CHAR(13) + CHAR(10) + '\par', CHAR(13) + CHAR(10));
  SET @RTFText = REPLACE(@RTFText, CHAR(10) + '\par', CHAR(13) + CHAR(10));
  SET @RTFText = REPLACE(@RTFText, '\par', CHAR(13) + CHAR(10));
  --
  SET @RTFText = REPLACE(@RTFText, '\''e4', 'ä');
  SET @RTFText = REPLACE(@RTFText, '\''f6', 'ö');
  SET @RTFText = REPLACE(@RTFText, '\''fc', 'ü');
  SET @RTFText = REPLACE(@RTFText, '\''c4', 'Ä');
  SET @RTFText = REPLACE(@RTFText, '\''d6', 'Ö');
  SET @RTFText = REPLACE(@RTFText, '\''dc', 'Ü');
  SET @RTFText = REPLACE(@RTFText, '\''e9', 'é');
  SET @RTFText = REPLACE(@RTFText, '\''e8', 'è');
  SET @RTFText = REPLACE(@RTFText, '\''eb', 'ë');
  SET @RTFText = REPLACE(@RTFText, '\''e2', 'â');
  SET @RTFText = REPLACE(@RTFText, '\''e0', 'à');
  SET @RTFText = REPLACE(@RTFText, '\''e7', 'ç');
  SET @RTFText = REPLACE(@RTFText, '\''ee', 'î');
  SET @RTFText = REPLACE(@RTFText, '\''b7', '-');
  --
  SET @RTFText = REPLACE(@RTFText, '\tab', CHAR(9));
  SET @RTFText = REPLACE(@RTFText, '\line', CHAR(13) + CHAR(10) + '----' + CHAR(13) + CHAR(10));
  SET @RTFText = REPLACE(@RTFText, '\li240', '-');
  
  -- fonts
  SET @RTFText = REPLACE(@RTFText, ' System;', '');
  SET @RTFText = REPLACE(@RTFText, ' Tahoma;', '');
  SET @RTFText = REPLACE(@RTFText, ' Arial;', '');
  SET @RTFText = REPLACE(@RTFText, ' Times New Roman;', '');
  SET @RTFText = REPLACE(@RTFText, ' Symbol;', '');
  SET @RTFText = REPLACE(@RTFText, ' MS Sans Serif;', '');
  SET @RTFText = REPLACE(@RTFText, ' Microsoft Sans Serif;', '');
  SET @RTFText = REPLACE(@RTFText, ' Verdana;', '');
  SET @RTFText = REPLACE(@RTFText, ' Courier New;', '');
  SET @RTFText = REPLACE(@RTFText, ' Windings;', '');
  SET @RTFText = REPLACE(@RTFText, ' Wingdings;', '');
  SET @RTFText = REPLACE(@RTFText, ' Wingdings2;', '');
  SET @RTFText = REPLACE(@RTFText, ' Wingdings3;', '');
  SET @RTFText = REPLACE(@RTFText, ' Comic Sans MS;', '');
  --
  SET @RTFText = REPLACE(@RTFText, '\fswiss', '');
  SET @RTFText = REPLACE(@RTFText, '\froman', '');
  SET @RTFText = REPLACE(@RTFText, '\fmodern', '');
  SET @RTFText = REPLACE(@RTFText, '\fnil', '');
  SET @RTFText = REPLACE(@RTFText, '\fbidis', '');
  SET @RTFText = REPLACE(@RTFText, '\fscript', '');
  
  -----------------------------------------------------------------------------
  -- remove counting tags
  -----------------------------------------------------------------------------
  DECLARE @CountUp INT;
  SET @CountUp = 50;
  
  WHILE (@CountUp > -1)
  BEGIN
    SET @RTFText = REPLACE(@RTFText, '\fprq' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\fcharset' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\protect' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\pnindent' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\expndtw' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\slmult' + CONVERT(VARCHAR(2), @CountUp), '');
    --
    SET @RTFText = REPLACE(@RTFText, '{\f' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\f' + CONVERT(VARCHAR(2), @CountUp), '');
    SET @RTFText = REPLACE(@RTFText, '\cf' + CONVERT(VARCHAR(2), @CountUp), '');  -- color from color table
    
    -- count down
    SET @CountUp = @CountUp - 1;
  END;
  
  -- handle fontsize (72p -> fs144)
  SET @CountUp = 144;
  
  WHILE (@CountUp > -1)
  BEGIN
    SET @RTFText = REPLACE(@RTFText, '\fs' + CONVERT(VARCHAR(3), @CountUp), '');  -- font size
    
    -- count down
    SET @CountUp = @CountUp - 1;
  END;
  
  -- colors
  SET @CountUp = 256;
  
  WHILE (@CountUp > -1)
  BEGIN
    SET @RTFText = REPLACE(@RTFText, '\red' + CONVERT(VARCHAR(3), @CountUp), '');       -- red
    SET @RTFText = REPLACE(@RTFText, '\green' + CONVERT(VARCHAR(3), @CountUp), '');     -- green
    SET @RTFText = REPLACE(@RTFText, 'lue' + CONVERT(VARCHAR(3), @CountUp) + ';', '');  -- blue (\b already removed above)
    
    -- count down
    SET @CountUp = @CountUp - 1;
  END;
  
  -----------------------------------------------------------------------------
  -- final replaces
  -----------------------------------------------------------------------------
  SET @RTFText = REPLACE(@RTFText, '\pn', '');
  
  -----------------------------------------------------------------------------
  -- remove crlf at the beginning
  -----------------------------------------------------------------------------
  WHILE (1 = 1)
  BEGIN
    IF (@RTFText LIKE CHAR(13) + '%' OR @RTFText LIKE CHAR(10) + '%')
    BEGIN
      SET @RTFText = LTRIM(RTRIM(SUBSTRING(@RTFText, 2, LEN(@RTFText))));
    END
    ELSE
    BEGIN
      -- we are done
      BREAK;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- remove crlf at the ending
  -----------------------------------------------------------------------------
  WHILE (1 = 1)
  BEGIN
    IF (@RTFText LIKE '%' + CHAR(13) OR @RTFText LIKE '%' + CHAR(10))
    BEGIN
      SET @RTFText = LTRIM(RTRIM(SUBSTRING(@RTFText, 1, LEN(@RTFText) - 1)));
    END
    ELSE
    BEGIN
      -- we are done
      BREAK;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN LTRIM(RTRIM(@RTFText));
END;
GO