@echo off
:menu
cls
echo ================================
echo Windows Servis Yonetim Araci
echo ================================
echo 1. Servis Baslat
echo 2. Servis Durdur
echo 3. Servisi Yeniden Baslat
echo 4. Servis Durumunu Kontrol Et
echo 5. Servisi Sil
echo 6. Servis Baslangic Turunu Degistir (Otomatik/Manuel/Devre Disi)
echo 7. Servisleri Listele
echo 8. Cikis
echo ================================
set /p choice="Lutfen bir secenek secin (1-7): "

if "%choice%"=="1" goto start_service
if "%choice%"=="2" goto stop_service
if "%choice%"=="3" goto restart_service
if "%choice%"=="4" goto check_status
if "%choice%"=="5" goto delete_service
if "%choice%"=="6" goto change_startup
if "%choice%"=="7" goto list_services
if "%choice%"=="8" goto exit_tool

:start_service
set /p service_name="Baslatmak istediginiz servis adini girin: "
sc start "%service_name%"
echo Servis baslatildi.
pause
goto menu

:stop_service
set /p service_name="Durdurmak istediginiz servis adini girin: "
sc stop "%service_name%"
echo Servis durduruldu.
pause
goto menu

:delete_service
set /p service_name="Silmek istediginiz servis adini girin: "
sc delete "%service_name%"
echo Servis silindi.
pause
goto menu

:restart_service
set /p service_name="Yeniden baslatmak istediginiz servis adini girin: "
sc stop "%service_name%"
sc start "%service_name%"
echo Servis yeniden baslatildi.
pause
goto menu

:check_status
set /p service_name="Durumunu kontrol etmek istediginiz servis adini girin: "
sc query "%service_name%"
pause
goto menu

:change_startup
set /p service_name="Baslangic turunu degistirmek istediginiz servis adini girin: "
echo 1. Otomatik
echo 2. Manuel
echo 3. Devre Disi
set /p startup_choice="Lutfen bir baslangic turu secin (1-3): "

if "%startup_choice%"=="1" sc config "%service_name%" start= auto
if "%startup_choice%"=="2" sc config "%service_name%" start= demand
if "%startup_choice%"=="3" sc config "%service_name%" start= disabled

echo Baslangic turu degistirildi.
pause
goto menu

:list_services
echo Mevcut servisler listeleniyor...
sc query state= all | findstr /R /C:"SERVICE_NAME:" /C:"STATE"
pause
goto menu

:exit_tool
echo Cikiliyor...
exit
