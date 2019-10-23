msbuild TerraCustom.sln /restore /t:clean /p:Configuration=WindowsRelease
msbuild TerraCustom.sln /t:clean /p:Configuration=MacRelease
msbuild TerraCustom.sln /t:clean /p:Configuration=LinuxRelease
msbuild TerraCustom.sln /p:Configuration=WindowsRelease
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
msbuild TerraCustom.sln /p:Configuration=MacRelease
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
msbuild TerraCustom.sln /p:Configuration=LinuxRelease
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)