using UnityEditor;
using System;
using System.IO;
using System.Linq;

namespace Matuba.Editor
{
    // 新しいスクリプトを作成時に作成者の名前と日付を追加する
    // Created by Matuba on 2024/07/01
    internal sealed class TemplateScriptProcessor : AssetModificationProcessor
    {
        // Unityはインポートしていないアセット(.metaファイルなど)を作成しようとするときにこのメソッドを呼び出します。
        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");

            if (path.EndsWith(".cs"))
            {
                if (!File.Exists(path)) { return; }

                Execute(path);
            }
        }

        private static void Execute(string path)
        {
            string content = ReadFile(path);
            content = SetAuthor(content);
            content = SetDate(content);

            WriteFile(path, content);
        }

        // スクリプトファイルを読み込む
        private static string ReadFile(string path)
        {
            using StreamReader reader = new(path);

            return reader.ReadToEnd();
        }

        // 作成者の名前を設定する
        private static string SetAuthor(string context)
        {
            var settings = LoadSettingFile();

            if (settings == null)
            {
                return context;
            }

            return context.Replace("#AUTHOR#", settings.AuthorName);
        }

        private static TemplateScriptSettings LoadSettingFile()
        {
            // プロジェクト内のアセットから指定の型のプロファイルを検索する
            var guids = AssetDatabase
                .FindAssets($"t:{nameof(TemplateScriptSettings)}")
                .FirstOrDefault();

            if (string.IsNullOrEmpty(guids))
            {
                UnityEngine.Debug.Log("Not Found TemplateScriptSettings");
                return null;
            }

            // GUIDからパスを取得してプロファイルの情報を取得する
            var path = AssetDatabase.GUIDToAssetPath(guids);

            return AssetDatabase.LoadAssetAtPath<TemplateScriptSettings>(path);
        }

        // 日付を設定する
        private static string SetDate(string context)
        {
            string dateString = DateTime.Now.ToString("yyyy/MM/dd");

            return context.Replace("#DATE#", dateString);
        }

        // スクリプトファイルに書き込む
        private static void WriteFile(string path, string context)
        {
            using StreamWriter writer = new(path, false);

            writer.Write(context);
        }
    }
}