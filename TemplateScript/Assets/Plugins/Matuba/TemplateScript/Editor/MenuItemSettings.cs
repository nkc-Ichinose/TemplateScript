using UnityEditor;
using System.IO;

namespace Matuba.Editor
{
    // テンプレートスクリプトを作成するためのメニューを追加するクラス
    // Created by Matuba on 2024/06/04
    static internal class MenuItemSettings
    {
        private const string PluginPath = "Assets/Plugins/Matuba/TemplateScript/";

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
            string path = Path.Combine(PluginPath, $"Templates/{templateFileName}");

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
    }
}