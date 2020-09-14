msbuild TerraCustom.sln /restore /p:Configuration=WindowsRelease
@IF %ERRORLEVEL% NEQ 0 (
pause
EXIT /B %ERRORLEVEL%
)
pause
