@echo off
 for /f "tokens=1-4 delims=/ " %%i in ("%date%") do (
 set dow=%%i
 set day=%%j
 set month=%%k
 set year=%%l
 )
 set datestr=%year%_%month%_%day%_%dow%
 echo datestr is %datestr%

set BACKUP_FILE=D:\SISTEMA_PAI\backup_sistema\database_erp_auto_%datestr%.backup
 echo backup file name is %BACKUP_FILE%
 SET PGPASSWORD=postgres
 echo on
 C:\"Arquivos de programas"\PostgreSQL\9.2\bin\pg_dump -i -h localhost -p 5432 -U postgres -F c -b -v -f %BACKUP_FILE% database_erp_auto