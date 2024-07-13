using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Matuba.Editor
{
    // テンプレートスクリプトの設定用のウィンドウを作成するクラス
    // Created by Name on 2024/07/14
    internal sealed class TemplateScriptSettingsWindow : EditorWindow
    {
        [SerializeField]
        private TemplateScriptSettings _settings;

        [MenuItem("Tools/Matuba/TemplateScriptSettings")]
        private static void ShowWindow()
        {
            var window = GetWindow<TemplateScriptSettingsWindow>();
            window.titleContent = new GUIContent("TemplateScriptSettings");
            window.Show();
        }

        private void OnGUI()
        {
            if (_settings == null)
            {
                _settings = LoadSettings();
            }

            string authorName = _settings.AuthorName;

            authorName = EditorGUILayout.TextField("AuthorName", authorName);

            // テキストの変更があった場合データを保存する
            if (EditorGUI.EndChangeCheck())
            {
                _settings.AuthorName = authorName;
                EditorUtility.SetDirty(_settings);
            }
        }

        // 設定ファイルを読み込む
        private TemplateScriptSettings LoadSettings()
        {
            return (TemplateScriptSettings)AssetDatabase.FindAssets("t:TemplateScriptSettings")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<ScriptableObject>)
                .FirstOrDefault();
        }
    }
}