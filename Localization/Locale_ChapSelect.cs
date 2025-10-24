using TMPro;
using UnityEngine;

public class Locale_ChapSelect : MonoBehaviour
{
    public LanguageSystem languageSystem;
    public TextAsset ChapSelectSceneText;
    private string Language;

    public GameObject SwitchGame;
    public TMP_Text SwitchGameText;
    public GameObject Settings;
    public TMP_Text SettingsText;
    public GameObject BackToTitle;
    public TMP_Text BackToTitleText;
    public TMP_Text BackText;

    //
    public TMP_Text TS_NewGameText;
    public TMP_Text TS_NewGameCoverText;
    public TMP_Text TS_ContinueText;
    public TMP_Text TS_ContinueCoverText;
    public TMP_Text TS_EpisodesText;
    public TMP_Text TS_EpisodesCoverText;

    //
    public TMP_Text TS_Chapter1Text;
    public TMP_Text TS_Chapter2Text;
    public TMP_Text TS_Chapter3Text;
    public TMP_Text TS_Chapter3p2Text;
    public TMP_Text TS_Chapter4Text;
    public TMP_Text TS_Chapter5Text;

    //
    public TMP_Text MLI_ComingSoonText;
    public TMP_Text MLI_ComingSoonCoverText;

    //
    public TMP_Text EoJ_ComingSoonText;
    public TMP_Text EoJ_ComingSoonCoverText;

    //
    public TMP_Text Museum_OrchestraText;
    public TMP_Text Museum_OrchestraCoverText;
    public TMP_Text Museum_TestSceneText;
    public TMP_Text Museum_TestSceneCoverText;
    public TMP_Text Museum_AnimStudioText;
    public TMP_Text Museum_AnimStudioCoverText;

    private void Start()
    {
        languageSystem.ReadText(ChapSelectSceneText);
    }

    private void Update()
    {
        Language = SettingsScript.Instance.Language;
        languageSystem.UpdateText(Language, 1, SwitchGameText);
        languageSystem.UpdateText(Language, 2, SettingsText);
        languageSystem.UpdateText(Language, 3, BackToTitleText);
        languageSystem.UpdateText(Language, 4, TS_NewGameText);
        languageSystem.UpdateText(Language, 4, TS_NewGameCoverText);
        languageSystem.UpdateText(Language, 5, TS_ContinueText);
        languageSystem.UpdateText(Language, 5, TS_ContinueCoverText);
        languageSystem.UpdateText(Language, 6, TS_EpisodesText);
        languageSystem.UpdateText(Language, 6, TS_EpisodesCoverText);
        languageSystem.UpdateText(Language, 7, Museum_OrchestraText);
        languageSystem.UpdateText(Language, 7, Museum_OrchestraCoverText);
        languageSystem.UpdateText(Language, 8, Museum_TestSceneText);
        languageSystem.UpdateText(Language, 8, Museum_TestSceneCoverText);
        languageSystem.UpdateText(Language, 9, Museum_AnimStudioText);
        languageSystem.UpdateText(Language, 9, Museum_AnimStudioCoverText);
        languageSystem.UpdateText(Language, 10, MLI_ComingSoonText);
        languageSystem.UpdateText(Language, 10, MLI_ComingSoonCoverText);
        languageSystem.UpdateText(Language, 10, EoJ_ComingSoonText);
        languageSystem.UpdateText(Language, 10, EoJ_ComingSoonCoverText);
        languageSystem.UpdateText(Language, 15, TS_Chapter1Text);
        languageSystem.UpdateText(Language, 16, TS_Chapter2Text);
        languageSystem.UpdateText(Language, 17, TS_Chapter3Text);
        languageSystem.UpdateText(Language, 18, TS_Chapter3p2Text);
        languageSystem.UpdateText(Language, 19, TS_Chapter4Text);
        languageSystem.UpdateText(Language, 20, TS_Chapter5Text);
        languageSystem.UpdateText(Language, 21, BackText);

        if (Language == "Chinese")
        {
            SwitchGame.GetComponent<RectTransform>().sizeDelta = new Vector2(206, 32);
            Settings.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 32);
            BackToTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(215, 32);
        }
        else if (Language == "English")
        {
            SwitchGame.GetComponent<RectTransform>().sizeDelta = new Vector2(280, 32);
            Settings.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 32);
            BackToTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 32);
        }
    }
}
