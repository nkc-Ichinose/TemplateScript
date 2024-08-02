# TemplateScript
テンプレートスクリプトを作成するツールです。

## UPM  
`https://github.com/nkc-Ichinose/TemplateScript.git?path=TemplateScript/Assets/Plugins/Matuba/TemplateScript`

## 使い方
導入後いつも通りC#スクリプトを追加しようとすると、C#Scriptの上に新しくTemplate C# Scriptと出るようになります。  
この中からテンプレートとして使いたいファイルを選びます。  
![スクリーンショット 2024-07-13 231348](https://github.com/user-attachments/assets/c76cffe9-63b0-4211-a48a-f548f28fb077)

### テンプレートの解説
#ROOTNAMESPACEBEGIN#と#ROOTNAMESPACEEND#の部分はassembly definitionで設定したnamespaceが入ります。  
#AUTHOR#は作成者の名前が入る部分です。  
#DATE#は作成した日付が入ります。  
![スクリーンショット 2024-07-14 030625](https://github.com/user-attachments/assets/3cdc7842-4c1f-4c04-ad3a-f162e68f62d9)

実際に作成するとこんな感じです。  
体裁が整っていませんがこれは下に書いてあるおすすめの拡張機能を入れることで解決できます。
![スクリーンショット 2024-07-14 030519](https://github.com/user-attachments/assets/9cb413ea-ce0d-4e00-a5b3-2e56c2ee7993)

### AuthorNameの変え方
1.画面上部のヘッダーメニューのTools>Matuba>TemplateScriptSettingsでウィンドウを開きます。  
![スクリーンショット 2024-07-14 023406](https://github.com/user-attachments/assets/062c5e8b-ce14-4ddb-aba0-d67ab2a6104a)

2.ウィンドウを開いたらAuthorNameを書き換えます。  
![スクリーンショット 2024-07-14 023811](https://github.com/user-attachments/assets/31b2240a-f808-46ba-a683-87ebd2b16c80)

### テンプレートの中身の変え方
Packages>TemplateScript>Templatesの中身がテンプレートファイルです。  
こちらを書き換えることでテンプレートの中身を変えられます。  
![スクリーンショット 2024-07-14 024725](https://github.com/user-attachments/assets/b38e1bf8-72c7-494a-98d2-1d212e2fa370)

## おすすめの拡張機能
Save on FormatをVisualStudioに導入することで保存をするだけでテンプレートの体裁をすぐに整えてくれます。  
詳しくは[こちら](https://note.com/matuba1335/n/n1761a1e297fb)をご覧ください。
