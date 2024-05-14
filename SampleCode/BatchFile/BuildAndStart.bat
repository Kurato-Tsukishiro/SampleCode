@chcp 65001
@rem 記事本体 : https://qiita.com/Kurato-Tsukishiro/items/b562e7e9e4409960dc2f

@echo off
cd %PrivateRepository%
dotnet build

if %errorlevel%==0 (start "" "%AmongUs%\Among Us") else ( pause ) 
