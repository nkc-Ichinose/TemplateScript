using UnityEditor;
using System.IO;

namespace Matuba.Editor
{
    // テンプレートスクリプトを作成するためのメニューを追加するクラス
    // Created by Matuba on 2024/06/04
    static internal class MenuItemSettings
    {
        private const string MenuItemRootPath = "Assets/Create/Template C# Script/";

        // メニューの優先度、C#Scriptの上に表示されるように設定
        private const int Priority = 30;

        // インターフェイス
        [MenuItem(itemName: MenuItemRootPath + "Interface", priority = Priority)]
        private static void CreateInterfaceScriptFile() => CreateScriptFile("Interface.txt", "NewInterface.cs");

        // PureC#
        [MenuItem(itemName: MenuItemRootPath + "PureC#", priority = Priority)]
        private static void CreatePureCSharpScriptFile() => CreateScriptFile("PureCSharp.txt", "NewPureCSharpScript.cs");

        // MonoBehaviour
        [MenuItem(itemName: MenuItemRootPath + "MonoBehaviour", priority = Priority)]
        private static void CreateMonoBehaviourScriptFile() => CreateScriptFile("MonoBehaviour.txt", "NewMonoBehaviourScript.cs");

        // スクリプタブルオブジェクト
        [MenuItem(itemName: MenuItemRootPath + "ScriptableObject", priority = Priority)]
        private static void CreateScriptableObjectFile() => CreateScriptFile("ScriptableObject.txt", "NewScriptableObject.cs");

        private static void CreateScriptFile(string templateFileName, string newScriptFileName)
        {
            string path = Path.Combine(GetPluginPath(), $"Templates/{templateFileName}");

            if (!File.Exists(path))
            {
                UnityEngine.Debug.LogError($"テンプレートファイルが見つかりませんでした。{path}");
                return;
            }

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile
            (
                path, newScriptFileName
            );
        }

        // このスクリプトの絶対ファイルパスを取得し、プラグインのパスを返す
        private static string GetPluginPath()
        {
            string path = GetFilePath();

            DirectoryInfo currentDirectory = new(path);

            return currentDirectory.Parent.Parent.ToString();
        }

        /// <summary>
        /// 呼び出し元のスクリプトのファイルパス(OS の絶対ファイルパス)を取得します。
        /// </summary>
        /// <param name="filePath">自動的に設定されます。</param>
        /// <returns>ファイルパス</returns>
        private static string GetFilePath([System.Runtime.CompilerServices.CallerFilePath] string filePath = null)
        {
            return filePath;
        }
    }
}