using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameFunc : MonoBehaviour
{
    public CourtRecordsSystem courtRecordsSystem;
    public GameBaseController gameBaseController;
    public SaveDataScripts saveDataScripts;
    public SettingsPanelScript settingsPanelScript;
    // 保存画面
    public GameObject SaveScreen;
    public GameObject SavePanel;
    public GameObject SaveComplete;
    public GameObject BtnBack;
    // Demo结束画面
    public GameObject DemoEndScreen;
    public GameObject DemoEndPanel;
    // 底部导航栏
    public GameObject BtnOpenCourtRecords;
    public GameObject BtnOptions;
    // 音效
    public AudioSource KetteiSFX;
    public AudioSource ShowOptionsSFX;
    public AudioSource ShowCourtRecordsSFX;
    public AudioSource HideCourtRecordsSFX;
    // 点击图层和箭头
    public GameObject ClickOverlay;
    public GameObject ProcessingArrow;

    private void Awake()
    {
        SaveScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && courtRecordsSystem.IsPanelHided)
        {
            if (settingsPanelScript.Hided == 1)
            {
                settingsPanelScript.OpenSettings();
                ShowOptionsSFX.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && settingsPanelScript.Hided == 1)
        {
            if (courtRecordsSystem.IsPanelHided)
            {
                ShowCourtRecords();
            }
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            if (!courtRecordsSystem.IsPanelHided)
            {
                HideCourtRecords();
            }
        }
        if (gameBaseController.Clickable == true && gameBaseController.DialogProcessing == false)
        {
            ProcessingArrow.SetActive(true);
        }
        if (gameBaseController.Clickable == false || gameBaseController.DialogProcessing == true)
        {
            ProcessingArrow.SetActive(false);
        }
    }
    // 显示保存画面
    public void ShowDialog()
    {
        SaveScreen.SetActive(true);
        SaveScreen.GetComponent<Graphic>().CrossFadeAlpha(.99f, .25f, false);
        Invoke("ShowPanel", .35f);
    }

    private void ShowPanel()
    {
        SavePanel.SetActive(true);
    }
    // 确认存档
    public void OnConfirmExit()
    {
        ReturnToChapSel();
    }
    // 取消退出
    public void OnCancelExit()
    {
        SaveScreen.SetActive(false);
        SaveScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        SavePanel.SetActive(false);
    }
    // 取消退出
    public void BackWithoutSave()
    {
        DemoEndScreen.GetComponent<Image>().DOFade(0, 1f);
        DemoEndPanel.GetComponent<CanvasGroup>().DOFade(0, 1f);
        DemoEndPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Invoke("ReturnToChapSel", 2f);
    }
    private void ReturnToChapSel()
    {
        SceneManager.LoadScene("ChapSelect");
    }

    public void ShowCourtRecords()
    {
        courtRecordsSystem.PanelTrigger();
        ShowCourtRecordsSFX.Play();
        BtnBack.SetActive(true);
        BtnOpenCourtRecords.SetActive(false);
        BtnOptions.SetActive(false);
        ClickOverlay.SetActive(false);
    }
    public void HideCourtRecords()
    {
        courtRecordsSystem.PanelTrigger();
        HideCourtRecordsSFX.Play();
        BtnBack.SetActive(false);
        BtnOpenCourtRecords.SetActive(true);
        BtnOptions.SetActive(true);
        ClickOverlay.SetActive(true);
    }
    public void ClickToHideCourtRecords()
    {
        courtRecordsSystem.NewEvidenceHide();
        gameBaseController.Clickable = true;
        KetteiSFX.Play();
    }
}