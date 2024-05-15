@chcp 65001 @rem バッチファイルの文字コードをUTF-8にする

@rem 230322_git pull UpStream-p & master and Develop branchs apply.
@rem リモートリポジトリから、全てのbranchを削除も反映してpullする
@rem Develop_fix、Develop_feature、develop、masterのローカルリポジトリを最新にする

@rem 記事本体 : https://qiita.com/Kurato-Tsukishiro/items/616288c2d246c0c9ad5a

cd Development_folder_exists_behind
git pull UpStream -p @rem fork元からpullする。削除も反映する

@ for /f "usebackq" %%i in (`"git symbolic-ref --short HEAD"`) do set now_branch=%%i @rem カレントブランチの名前を変数に格納する
@echo "現在のbranchは [ "%now_branch%" ] です。" @rem @echoにしない場合「現在の～」が2つ出力される

git checkout -B Develop_fix UpStream/Develop_fix
git checkout -B Develop_feature UpStream/Develop_feature
git checkout -B develop UpStream/develop
git checkout -B master UpStream/master

git checkout %now_branch% @rem checkoutコマンド使用前に取得したブランチに移動する

@rem 通常時は実行結果を確認しない
@rem pause
