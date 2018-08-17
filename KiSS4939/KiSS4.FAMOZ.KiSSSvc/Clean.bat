rmdir /Q /S _ReSharper.KiSSSvc
for /D %%1 in (KiSSSvc.*) do rmdir /Q /S %%1\obj
for /D %%1 in (KiSSSvc.*) do rmdir /Q /S %%1\bin
