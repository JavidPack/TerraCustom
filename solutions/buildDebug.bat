msbuild TerraCustom.sln /restore /p:Configuration=WindowsDebug
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
