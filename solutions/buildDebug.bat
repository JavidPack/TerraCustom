msbuild TerraCustom.sln /p:Configuration=WindowsDebug /p:Platform="x86"
@IF %ERRORLEVEL% NEQ 0 (EXIT /B %ERRORLEVEL%)
