using System.IO;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeScreen : MonoBehaviour
{
    public SettingsScript settingsScript;
    public SystemDataScripts systemDataScripts;

    public GameObject Gear;
    public GameObject AlertBG;
    public CanvasGroup SelectLanguageBtns;
    public CanvasGroup Warning;
    public GameObject WarningTextCN;
    public GameObject WarningTextEN;

    Vector3 _vec3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _vec3.Set(0, 0, -360f);
        Gear.transform.DOLocalRotate(_vec3, 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetId("GearRotate");
        Invoke("DetectSystemData", 2.5f);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void DetectSystemData()
    {
        Gear.SetActive(false);
        if (settingsScript.FirstRun)
        {
            DOTween.Kill("GearRotate");
            DisplayAlertBG();
            Invoke("SelectLanguage", .6f);
        }
        else
        {
            DOTween.Kill("GearRotate");
            DisplayAlertBG();
            Invoke("ShowWarning", .6f);
        }
    }
    public void SelectLanguage()
    {
        SelectLanguageBtns.alpha = 1;
        SelectLanguageBtns.blocksRaycasts = true;
    }
    public void LanguageSelected(string Language)
    {
        if (Language == "Chinese")
        {
            settingsScript.Language = "Chinese";
        }
        else if (Language == "English")
        {
            settingsScript.Language = "English";
        }
        else
        {
            settingsScript.Language = "Chinese";
        }
        settingsScript.FirstRun = false;
        systemDataScripts.SaveBySerialization();
        AlertBG.SetActive(false);
        AlertBG.GetComponent<Image>().DOFade(0, 0f);
        SelectLanguageBtns.alpha = 0;
        SelectLanguageBtns.blocksRaycasts = false;
        Invoke("DisplayAlertBG", .5f);
        Invoke("ShowWarning", .6f);
    }
    public void DisplayAlertBG()
    {
        AlertBG.SetActive(true);
        AlertBG.GetComponent<Image>().DOFade(1, .5f);
    }
    public void WarningReaded()
    {
        Warning.alpha = 0;
        Warning.blocksRaycasts = false;
        AlertBG.SetActive(false);
        Gear.SetActive(true);
        _vec3.Set(0, 0, -360f);
        Gear.transform.DOLocalRotate(_vec3, 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        Invoke("LoadMenu", 2f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowWarning()
    {
        if(settingsScript.Language == "Chinese")
        {
            WarningTextCN.SetActive(true);
        }
        else if(settingsScript.Language == "English")
        {
            WarningTextEN.SetActive(true);
        }
        Warning.alpha = 1;
        Warning.blocksRaycasts = true;
    }
}
