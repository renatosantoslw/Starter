echo off
cls
setlocal enabledelayedexpansion

@echo ***********************************************
@echo ***                                         ***
@echo ***               WT SOFTWARE               ***
@echo ***                                         ***
@echo ***********************************************
@echo *  1. INSTALANDO POSTRGESQL                   *
@echo ***********************************************
#postgresql-9.2.20-2-windows-x64.exe --unattendedmodeui minimal --mode unattended --superaccount postgres --servicename PostgreSQL --install_runtimes 1 --create_shortcuts 1 --superpassword postgres --serverport 5432

@echo ***********************************************
@echo *  2. CRIANDO DATABASE                        *
@echo ***********************************************
SET DIRETORIO_ATUAL=%cd%
SET DIRETORIO_POSTGRES=C:\Program Files\PostgreSQL\9.2\
SET DB_NAME=database_pdv_teste

IF EXIST "%DIRETORIO_POSTGRES%bin\psql.exe" SET PSQL_DIR="%DIRETORIO_POSTGRES%bin\"
IF EXIST "%DIRETORIO_POSTGRES%bin\psql.exe" SET PSQL_DIR="%DIRETORIO_POSTGRES%bin\"

cd %PSQL_DIR%
set PGPASSWORD=postgres

psql.exe -h localhost -p 5432 -U postgres "drop database if exists %DB_NAME%"
psql.exe -h localhost -p 5432 -U postgres -c "create database %DB_NAME%"

@echo ***********************************************
@echo *  3. CRIANDO TABELAS                         *
@echo ***********************************************
psql.exe -h localhost -p 5432 -U postgres -d %DB_NAME% -f "%DIRETORIO_ATUAL%\arquivo.sql"

@echo ***********************************************
@echo *  4. LIBERANDO PORTAS FIREWALL               *
@echo ***********************************************
netsh firewall set portopening TCP 5432 "PostgreSQL"

@echo ***********************************************
@echo *  5. LIBERANDO PG_HBA.CONF                   *
@echo ***********************************************
copy "%DIRETORIO_ATUAL%\pg_hba.conf" "%DIRETORIO_POSTGRES%data\pg_hba.conf"

@echo ***********************************************
@echo *  6. INSTALANDO ZEUS PDV                     *
@echo ***********************************************
#PDV.VIEW.SETUP.msi
pause