SELECT HerkunftSQL = REPLACE(REPLACE(REPLACE(HerkunftSQL, '''', ''''''), CHAR(13), ''' + CHAR(13) + '''), CHAR(10), ''' + CHAR(10) + ''')
FROM BFSFrage