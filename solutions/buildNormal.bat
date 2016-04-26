msbuild TerraCustom.sln /p:Configuration=WindowsRelease /p:Platform="x86"
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
