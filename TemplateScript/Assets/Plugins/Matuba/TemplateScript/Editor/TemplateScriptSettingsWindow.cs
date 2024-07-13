using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Matuba.Editor
{
    // クラスの役割
    // Created by Name on 2024/07/14
    internal sealed class TemplateScriptSettingsWindow : EditorWindow
    {
        [SerializeField]
        private TemplateScriptSettings _settings;

        [MenuItem("Matuba/TemplateScriptSettings")]
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

            if (EditorGUI.EndChangeCheck())
            {
                _settings.AuthorName = authorName;
                EditorUtility.SetDirty(_settings);
            }
        }

        private TemplateScriptSettings LoadSettings()
        {
            return (TemplateScriptSettings)AssetDatabase.FindAssets("t:TemplateScriptSettings")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<ScriptableObject>)
                .FirstOrDefault();
        }
    }
}