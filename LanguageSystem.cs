using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSystem : MonoBehaviour
{
    private string[] TextRows;
    public void ReadText(TextAsset _textAsset)
    {
        TextRows = _textAsset.text.Split('\n');
    }
    public void UpdateText(string Language, int TextIndex, TMP_Text TextObject)
    {
        string[] TextColumns = TextRows[TextIndex].Split(',');
        if (Language == "Chinese") {
            TextObject.text = TextColumns[2];
        }
        else if (Language == "English")
        {
            TextObject.text = TextColumns[3];
        }
    }
}