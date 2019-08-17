:: After Pulling, Patching, and making sure the version number is changed in src, this bat will compile and create zips for all release.
:: It will also create a zip for ExampleMod

set version=v0.6.1
set exeFile=TerraCustom %version%.exe
set exeFileMacLinux=TerraCustom.exe
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
set win=%destinationFolder%\TerraCustom Windows %version%
set mac=%destinationFolder%\TerraCustom Mac %version%
set lnx=%destinationFolder%\TerraCustom Linux %version%

mkdir "%win%"
mkdir "%mac%"
mkdir "%lnx%"

:: Windows release
copy ..\src\TerraCustom\bin\WindowsRelease\net45\Terraria.exe "%win%\%exeFile%" /y
copy ReleaseExtras\README_Windows.txt "%win%\README.txt" /y

call zipjs.bat zipDirItems -source "%win%" -destination "%win%.zip" -keep yes -force yes

:: Mac release
copy ..\src\TerraCustom\bin\MacRelease\net45\Terraria.exe "%mac%\%exeFileMacLinux%" /y
copy ReleaseExtras\README_Mac.txt "%mac%\README.txt" /y
copy ReleaseExtras\TerraCustom "%mac%\TerraCustom" /y
copy ..\references\I18N.dll "%mac%\I18N.dll" /y
copy ..\references\I18N.West.dll "%mac%\I18N.West.dll" /y
mkdir "%mac%\osx"
copy ReleaseExtras\osx "%mac%\osx" /y

call zipjs.bat zipDirItems -source "%mac%" -destination "%mac%.zip" -keep yes -force yes

:: Linux release
copy ..\src\TerraCustom\bin\LinuxRelease\net45\Terraria.exe "%lnx%\%exeFileMacLinux%" /y
copy ReleaseExtras\README_Linux.txt "%lnx%\README.txt" /y
copy ReleaseExtras\TerraCustom "%lnx%\TerraCustom" /y
copy ..\references\I18N.dll "%lnx%\I18N.dll" /y
copy ..\references\I18N.West.dll "%lnx%\I18N.West.dll" /y

call zipjs.bat zipDirItems -source "%lnx%" -destination "%lnx%.zip" -keep yes -force yes

:: CleanUp, Delete temp Folders
rmdir "%win%" /S /Q
rmdir "%mac%" /S /Q
rmdir "%lnx%" /S /Q

echo(
echo(
echo(
echo TerraCustom %version% ready to release.
echo Upload the 3 zip files to github.
echo(
echo(
pause
