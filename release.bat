SET BAT_LOG=%~dp0release.log
echo Build VitDeck release files. > %BAT_LOG% 2>&1
echo %date% %time% >> %BAT_LOG% 2>&1
if "%1"=="" (
 set /p VERSION="input VERSION:"
) else (
 set  VERSION=%1
)
echo VERSION: %VERSION% >> %BAT_LOG% 2>&1
set UNITY_PATH="C:\Program Files\Unity\Hub\Editor\2017.4.15f1\Editor\Unity.exe" >> %BAT_LOG% 2>&1
set LOG_FILE="release-unity.log" >> %BAT_LOG% 2>&1
set PACKAGE_NAME="VitDeck-%VERSION%.unitypackage" >> %BAT_LOG% 2>&1
set VITDECK_ROOT="Assets\VitDeck" >> %BAT_LOG% 2>&1
set RELEASE_PATH="Release\VitDeck" >> %BAT_LOG% 2>&1

@rem Remove Test folder
del /Q %VITDECK_ROOT%\AssetGuardian\Tests >> %BAT_LOG% 2>&1
del /Q %VITDECK_ROOT%Exporter\Tests >> %BAT_LOG% 2>&1
del /Q %VITDECK_ROOT%\Main\Tests >> %BAT_LOG% 2>&1
del /Q %VITDECK_ROOT%\TemplateLoader\Tests >> %BAT_LOG% 2>&1
del /Q %VITDECK_ROOT%\Utilities\Tests >> %BAT_LOG% 2>&1
del /Q %VITDECK_ROOT%\Validator\Tests >> %BAT_LOG% 2>&1

@rem Export unitypackage
subst Z: . >> %BAT_LOG% 2>&1
%UNITY_PATH%^
 -exportPackage %VITDECK_ROOT% %PACKAGE_NAME%^
 -projectPath "Z:\VitDeck"^
 -batchmode^
 -nographics^
 -logfile %LOG_FILE%^
 -quit

@rem Move to Release folder
mkdir %RELEASE_PATH% >> %BAT_LOG% 2>&1
move .\VitDeck\%PACKAGE_NAME% %RELEASE_PATH% >> %BAT_LOG% 2>&1
copy /Y LICENSE %RELEASE_PATH% >> %BAT_LOG% 2>&1
copy /Y README.md %RELEASE_PATH% >> %BAT_LOG% 2>&1
move %RELEASE_PATH%\README.md %RELEASE_PATH%\README.txt >> %BAT_LOG% 2>&1
subst Z: /D
