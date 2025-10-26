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
    // ���滭��
    public GameObject SaveScreen;
    public GameObject SavePanel;
    public GameObject SaveComplete;
    public GameObject BtnBack;
    // Demo��������
    public GameObject DemoEndScreen;
    public GameObject DemoEndPanel;
    // �ײ�������
    public GameObject BtnOpenCourtRecords;
    public GameObject BtnOptions;
    // ��Ч
    public AudioSource KetteiSFX;
    public AudioSource ShowOptionsSFX;
    public AudioSource ShowCourtRecordsSFX;
    public AudioSource HideCourtRecordsSFX;
    // ���ͼ��ͼ�ͷ
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
    // ��ʾ���滭��
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
    // ȷ�ϴ浵
    public void OnConfirmExit()
    {
        ReturnToChapSel();
    }
    // ȡ���˳�
    public void OnCancelExit()
    {
        SaveScreen.SetActive(false);
        SaveScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        SavePanel.SetActive(false);
    }
    // ȡ���˳�
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