setlocal
set BAT_LOG=%~dp0release.log
echo Build VitDeck release files. > %BAT_LOG% 2>&1
echo %date% %time% >> %BAT_LOG% 2>&1
if "%1"=="" (
 set /p VERSION="input VERSION:"
) else (
 set  VERSION=%1
)
echo VERSION: %VERSION% >> %BAT_LOG% 2>&1
set UNITY_PATH="C:\Program Files\Unity\Hub\Editor\2017.4.15f1\Editor\Unity.exe"
set LOG_FILE="release-unity.log"
set PACKAGE_NAME="VitDeck-%VERSION%.unitypackage"
set VITDECK_ROOT=Assets\VitDeck
set RELEASE_PATH=Release\VitDeck

echo Remove Test folder >> %BAT_LOG% 2>&1
del /Q VitDeck\%VITDECK_ROOT%\AssetGuardian\Tests
del /Q VitDeck\%VITDECK_ROOT%\Exporter\Tests
del /Q VitDeck\%VITDECK_ROOT%\Main\Tests
del /Q VitDeck\%VITDECK_ROOT%\TemplateLoader\Tests
del /Q VitDeck\%VITDECK_ROOT%\Utilities\Tests
del /Q VitDeck\%VITDECK_ROOT%\Validator\Tests

echo Copy documents >> %BAT_LOG% 2>&1
copy /Y LICENSE VitDeck\%VITDECK_ROOT%\LICENSE.txt >> %BAT_LOG% 2>&1
copy /Y README.md VitDeck\%VITDECK_ROOT%\README.txt >> %BAT_LOG% 2>&1


echo Mount >> %BAT_LOG% 2>&1
subst Z: . >> %BAT_LOG% 2>&1

echo Export unitypackage >> %BAT_LOG% 2>&1
%UNITY_PATH%^
 -exportPackage %VITDECK_ROOT% %PACKAGE_NAME%^
 -projectPath "Z:\VitDeck"^
 -batchmode^
 -nographics^
 -logfile %LOG_FILE%^
 -quit

echo Move to Release folder >> %BAT_LOG% 2>&1
mkdir %RELEASE_PATH% >> %BAT_LOG% 2>&1
move .\VitDeck\%PACKAGE_NAME% %RELEASE_PATH% >> %BAT_LOG% 2>&1

echo Unmount >> %BAT_LOG% 2>&1
subst Z: /D
