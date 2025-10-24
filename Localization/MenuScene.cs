using TMPro;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    public LanguageSystem languageSystem;
    public TextAsset MenuSceneText;
    private string Language;

    // 按钮
    public TMP_Text ChapSelectText;
    public TMP_Text SettingsText;
    public TMP_Text CreditsText;
    public TMP_Text QQGroupText;
    public TMP_Text ExitText;
    public TMP_Text ExitMaskText;

    // 确认结束界面
    public TMP_Text ExitConfirmText;
    public TMP_Text ExitYesText;
    public TMP_Text ExitNoText;
    public TMP_Text JumpConfirmText;
    public TMP_Text JumpYesText;
    public TMP_Text JumpNoText;

    private void Update()
    {
        Language = SettingsScript.Instance.Language;
        languageSystem.UpdateText(Language, 1, ChapSelectText);
        languageSystem.UpdateText(Language, 2, SettingsText);
        languageSystem.UpdateText(Language, 3, CreditsText);
        languageSystem.UpdateText(Language, 4, QQGroupText);
        languageSystem.UpdateText(Language, 5, ExitText);
        languageSystem.UpdateText(Language, 5, ExitMaskText);
        languageSystem.UpdateText(Language, 6, ExitConfirmText);
        languageSystem.UpdateText(Language, 7, ExitYesText);
        languageSystem.UpdateText(Language, 8, ExitNoText);
        languageSystem.UpdateText(Language, 9, JumpConfirmText);
        languageSystem.UpdateText(Language, 10, JumpYesText);
        languageSystem.UpdateText(Language, 11, JumpNoText);
    }
    private void Start()
    {
        languageSystem.ReadText(MenuSceneText);
    }
}