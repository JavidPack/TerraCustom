msbuild TerraCustom.sln /p:Configuration=WindowsRelease /p:Platform="x86"
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
msbuild TerraCustom.sln /p:Configuration=MacRelease /p:Platform="x86"
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
msbuild TerraCustom.sln /p:Configuration=LinuxRelease /p:Platform="x86"
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)