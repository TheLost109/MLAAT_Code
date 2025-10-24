using TMPro;
using UnityEngine;

public class SettingsPrefab : MonoBehaviour
{
    public LanguageSystem languageSystem;
    public TextAsset SettingsPrefabText;
    private string Language;

    public TMP_Text SettingsTitleText;
    public TMP_Text CloseSettingsText;

    public TMP_Text AudioSettingsText;
    public TMP_Text AudioSettingsTextSel;
    public TMP_Text BGMSettingsText;
    public TMP_Text SESettingsText;

    public TMP_Text LanguageText;
    public TMP_Text LanguageTextSel;
    public TMP_Text TextLanguageText;
    public TMP_Text AudioLanguageText;

    public TMP_Text PCConfigText;
    public TMP_Text PCConfigTextSel;
    public TMP_Text ResolutionText;
    public TMP_Text FullscreenText;
    public TMP_Text AntiAliasingText;
    public TMP_Text VSyncText;
    public TMP_Text MaxFPSText;

    private void Update()
    {
        Language = SettingsScript.Instance.Language;
        languageSystem.UpdateText(Language, 1, SettingsTitleText);
        languageSystem.UpdateText(Language, 2, CloseSettingsText);
        languageSystem.UpdateText(Language, 3, AudioSettingsText);
        languageSystem.UpdateText(Language, 3, AudioSettingsTextSel);
        languageSystem.UpdateText(Language, 4, BGMSettingsText);
        languageSystem.UpdateText(Language, 5, SESettingsText);
        languageSystem.UpdateText(Language, 6, LanguageText);
        languageSystem.UpdateText(Language, 6, LanguageTextSel);
        languageSystem.UpdateText(Language, 7, TextLanguageText);
        languageSystem.UpdateText(Language, 8, AudioLanguageText);
        languageSystem.UpdateText(Language, 12, PCConfigText);
        languageSystem.UpdateText(Language, 12, PCConfigTextSel);
        languageSystem.UpdateText(Language, 13, ResolutionText);
        languageSystem.UpdateText(Language, 14, FullscreenText);
        languageSystem.UpdateText(Language, 17, VSyncText);
        languageSystem.UpdateText(Language, 18, AntiAliasingText);
        languageSystem.UpdateText(Language, 19, MaxFPSText);
    }
    private void Start()
    {
        languageSystem.ReadText(SettingsPrefabText);
    }
}
