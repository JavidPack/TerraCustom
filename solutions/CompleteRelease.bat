:: After Pulling, Patching, and making sure the version number is changed in src, this bat will compile and create zips for all release.
:: It will also create a zip for ExampleMod

set version=v0.5.4
set exeFile=TerraCustom %version%.exe
set destinationFolder=.\TerraCustom %version% Release

:: Compile/Build exe 
call buildRelease.bat
@IF %ERRORLEVEL% NEQ 0 (
	pause
	EXIT /B %ERRORLEVEL%
)

:: Folder for release
mkdir "%destinationFolder%"

:: Temp Folders
mkdir "%destinationFolder%\TerraCustom Windows %version%"
mkdir "%destinationFolder%\TerraCustom Mac %version%"
mkdir "%destinationFolder%\TerraCustom Linux %version%"

:: Windows release
copy ..\src\TerraCustom\bin\x86\WindowsRelease\Terraria.exe "%destinationFolder%\TerraCustom Windows %version%\%exeFile%" /y
copy ReleaseExtras\README_Windows.txt "%destinationFolder%\TerraCustom Windows %version%\README.txt" /y

call zipjs.bat zipDirItems -source "%destinationFolder%\TerraCustom Windows %version%" -destination "%destinationFolder%\TerraCustom Windows %version%.zip" -keep yes -force yes

:: Mac release
copy ..\src\TerraCustom\bin\x86\MacRelease\Terraria.exe "%destinationFolder%\TerraCustom Mac %version%\%exeFile%" /y
:: References
copy ..\references\MP3Sharp.dll "%destinationFolder%\TerraCustom Mac %version%\MP3Sharp.dll" /y
copy ..\references\Ionic.Zip.Reduced.dll "%destinationFolder%\TerraCustom Mac %version%\Ionic.Zip.Reduced.dll" /y
copy ..\references\Mono.Cecil.dll "%destinationFolder%\TerraCustom Mac %version%\Mono.Cecil.dll" /y
copy ReleaseExtras\README_Mac.txt "%destinationFolder%\TerraCustom Mac %version%\README.txt" /y

call zipjs.bat zipDirItems -source "%destinationFolder%\TerraCustom Mac %version%" -destination "%destinationFolder%\TerraCustom Mac %version%.zip" -keep yes -force yes

:: Linux release
copy ..\src\TerraCustom\bin\x86\LinuxRelease\Terraria.exe "%destinationFolder%\TerraCustom Linux %version%\%exeFile%" /y
:: References
copy ..\references\MP3Sharp.dll "%destinationFolder%\TerraCustom Linux %version%\MP3Sharp.dll" /y
copy ..\references\Ionic.Zip.Reduced.dll "%destinationFolder%\TerraCustom Linux %version%\Ionic.Zip.Reduced.dll" /y
copy ..\references\Mono.Cecil.dll "%destinationFolder%\TerraCustom Linux %version%\Mono.Cecil.dll" /y
copy ReleaseExtras\README_Linux.txt "%destinationFolder%\TerraCustom Linux %version%\README.txt" /y

call zipjs.bat zipDirItems -source "%destinationFolder%\TerraCustom Linux %version%" -destination "%destinationFolder%\TerraCustom Linux %version%.zip" -keep yes -force yes

:: CleanUp, Delete temp Folders
rmdir "%destinationFolder%\TerraCustom Windows %version%" /S /Q
rmdir "%destinationFolder%\TerraCustom Mac %version%" /S /Q
rmdir "%destinationFolder%\TerraCustom Linux %version%" /S /Q

echo(
echo(
echo(
echo TerraCustom %version% ready to release.
echo(
echo(
pause
