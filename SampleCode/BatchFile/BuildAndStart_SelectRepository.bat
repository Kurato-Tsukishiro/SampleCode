@chcp 65001
@echo off
rem 記事本体 : https://qiita.com/Kurato-Tsukishiro/items/b562e7e9e4409960dc2f

:Select_Input
echo +-------------------------------------------------------------------+
echo  どのLocalRepositoryを使用していますか? 該当する数字を入力してください。
echo      1. Private_Repository
echo      2. Public_Repository
echo +-------------------------------------------------------------------+
Set /P INPUT_NO=
if "%INPUT_NO%"=="1" GOTO :Private_Repository
if "%INPUT_NO%"=="2" GOTO :Public_Repository
GOTO :Select_Input

:Private_Repository
echo +--------------------------------+
echo   Private_Repository に移動します。
echo +--------------------------------+
cd %PrivateRepository%
GOTO :Build_And_Start

:Public_Repository
echo +--------------------------------+
echo   Public_Repository に移動します。
echo +--------------------------------+
cd %PublicRepository%
GOTO :Build_And_Start

:Build_And_Start
if %errorlevel%==0 (start "" "%AmongUs%\Among Us") else ( pause ) 
