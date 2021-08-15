setlocal
echo Build VitDeck release files.
echo %date% %time%
if "%1"=="" (
 set /p VERSION="input VERSION:"
) else (
 set  VERSION=%1
)
echo VERSION: %VERSION%
set UNITY_PATH="C:\Program Files\Unity\Hub\Editor\2018.4.20f1\Editor\Unity.exe"
set LOG_FILE="release-unity.log"
set PACKAGE_NAME="VitDeck-%VERSION%.unitypackage"
set RELEASE_INFO_JSON="latest.json"
set VITDECK_ROOT=Assets\VitDeck
set RELEASE_PATH=Release\VitDeck

echo Remove Test folder
call :DelFolder "%VITDECK_ROOT%\AssetGuardian\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\Exporter\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\Main\ValidatedExporter\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\Main\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\TemplateLoader\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\Utilities\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\Validator\Tests" "%BAT_LOG%"
call :DelFolder "%VITDECK_ROOT%\TestUtilities" "%BAT_LOG%"

echo Delete UserSettings.asset
del /s /q "%VITDECK_ROOT%\Config\UserSettings.asset"

echo Copy documents
copy /Y LICENSE "%VITDECK_ROOT%\LICENSE.txt"
copy /Y releaseAssets\LICENSE.txt.meta "%VITDECK_ROOT%\LICENSE.txt.meta"
copy /Y README.md "%VITDECK_ROOT%\README.txt"
copy /Y releaseAssets\README.txt.meta "%VITDECK_ROOT%\README.txt.meta"


echo Mount
subst Z: .

echo Export unitypackage
%UNITY_PATH%^
 -exportPackage %VITDECK_ROOT% %PACKAGE_NAME%^
 -projectPath "Z:\"^
 -batchmode^
 -nographics^
 -logfile %LOG_FILE%^
 -quit

echo Generate json file
echo { > %RELEASE_INFO_JSON% 2>&1
echo  "version": "%VERSION%", >> %RELEASE_INFO_JSON% 2>&1
echo  "package_name": "VitDeck-%VERSION%.unitypackage", >> %RELEASE_INFO_JSON% 2>&1
echo  "download_url": "https://github.com/vitdeck/VitDeck/releases/download/%VERSION%/VitDeck-%VERSION%.unitypackage" >> %RELEASE_INFO_JSON% 2>&1
echo } >> %RELEASE_INFO_JSON% 2>&1

echo Move to Release folder
mkdir %RELEASE_PATH%
move %PACKAGE_NAME% %RELEASE_PATH%
move %RELEASE_INFO_JSON% %RELEASE_PATH%

echo Unmount
subst Z: /D

exit /b


REM Delete folder
:DelFolder
rmdir /s /q %1
if not exist %1 (
echo Success rmdir /s /q %1 >> %2
) else (
echo Error rmdir /s /q %1 >> %2
)
exit /b
