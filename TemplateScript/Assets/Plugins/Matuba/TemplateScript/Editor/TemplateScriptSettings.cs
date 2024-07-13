using UnityEngine;

namespace Matuba.Editor
{
    // テンプレートスクリプトの設定用のアセットを作成するクラス
    // 一つのプロジェクトに一つだけ作成することを想定しているため、CreateAssetMenu属性をコメントアウトしている
    // Created by Matuba on 2024/07/12
    //[CreateAssetMenu(menuName = "Matuba/TemplateScriptSettings", fileName = "TemplateScriptSettings", order = 100)]
    internal sealed class TemplateScriptSettings : ScriptableObject
    {
        [SerializeField]
        private string _authorName;

        public string AuthorName
        {
            get => _authorName;
            set => _authorName = value;
        }
    }
}