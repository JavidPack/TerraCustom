:: After Pulling, Patching, and making sure the version number is changed in src, this bat will compile and create zips for all release.
:: It will also create a zip for ExampleMod

@ECHO off
:: Compile/Build exe 
echo "Building Release"
set TerraCustomVersion=v0.8
call buildRelease.bat

set destinationFolder=.\TerraCustom %TerraCustomVersion% Release
@IF %ERRORLEVEL% NEQ 0 (
	pause
	EXIT /B %ERRORLEVEL%
)
@ECHO on

:: Folder for release
mkdir "%destinationFolder%"

:: Temp Folders
set win=%destinationFolder%\TerraCustom Windows %TerraCustomVersion%
set mac=%destinationFolder%\TerraCustom Mac %TerraCustomVersion%
set macReal=%destinationFolder%\TerraCustom Mac %TerraCustomVersion%\TerraCustom.app\Contents\MacOS
set lnx=%destinationFolder%\TerraCustom Linux %TerraCustomVersion%

mkdir "%win%"
mkdir "%mac%"
mkdir "%lnx%"

:: Windows release
robocopy /s ReleaseExtras\JourneysEndCompatibilityContent "%win%\Content"
robocopy /s ReleaseExtras\WindowsFiles "%win%"
copy ..\src\TerraCustom\bin\WindowsRelease\net45\Terraria.exe "%win%\TerraCustom.exe" /y

call python ZipAndMakeExecutable.py "%win%" "%win%.zip"

:: Linux release
robocopy /s ReleaseExtras\LinuxFiles "%lnx%"
robocopy /s ReleaseExtras\LinuxMacSharedFiles "%lnx%"
robocopy /s ReleaseExtras\JourneysEndCompatibilityContent "%lnx%\Content"
copy ..\src\TerraCustom\bin\LinuxRelease\net45\Terraria.exe "%lnx%\TerraCustom.exe" /y
copy ReleaseExtras\TerraCustom "%lnx%\TerraCustom" /y

call python ZipAndMakeExecutable.py "%lnx%" "%lnx%.tar.gz"
call python ZipAndMakeExecutable.py "%lnx%" "%lnx%.zip"

:: Mac release
robocopy /s ReleaseExtras\MacFiles "%mac%"
robocopy /s ReleaseExtras\LinuxMacSharedFiles "%macReal%"
robocopy /s ReleaseExtras\JourneysEndCompatibilityContent "%macReal%\Content"
copy ..\src\TerraCustom\bin\MacRelease\net45\Terraria.exe "%macReal%\tModLoader.exe" /y
copy ReleaseExtras\TerraCustom "%macReal%\TerraCustom" /y

call python ZipAndMakeExecutable.py "%mac%" "%mac%.zip"

:: CleanUp, Delete temp Folders
rmdir "%win%" /S /Q
rmdir "%mac%" /S /Q
rmdir "%lnx%" /S /Q

echo(
echo(
echo(
echo TerraCustom %TerraCustomVersion% ready to release.
echo Upload the 6 zip files to github.
echo(
echo(
pause
