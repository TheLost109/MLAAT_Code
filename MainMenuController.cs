using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class MainMenuController : MonoBehaviour
{
    public GameObject JumpScreen;
    public GameObject JumpPanel;
    public GameObject CourtDoorVideo;
    public AudioSource CourtDoorSFX;
    public GameObject MLAATLogo;
    public CanvasGroup ButtonsGroup;
    public CanvasGroup ExitButton;
    public AudioWithIntro TitleMusic;
    public RenderTexture title_bg;
    public GameObject title_bg_iml3;

    // Credits 相关
    public GameObject CreditsScreen;
    public AudioSource ExitSFX;
    public AudioSource CreditMusic;
    private bool InCredits = false;

    // 结束游戏 相关
    public GameObject ExitScreen; // 结束画面
    public GameObject ExitPanel; // 结束面板

    //“结束游戏” 按钮动效
    public Vector4 BtnMaskPadding0;
    public Vector4 BtnMaskPadding224;
    public GameObject ExitGameBtnMask;

    // 彩蛋
    //public AudioSource SE_Ayashii;
    //public GameObject GeoMeGeoYouObject;
    //public RenderTexture GeoMeGeoYouRT;
    //private int EasterEggCount = 0;
    //private int InEasterEgg = 0;

    private void Start()
    {
        title_bg_iml3.GetComponent<Image>().DOFade(0, 0);
        Invoke("DoorStart", .5f);
        Invoke("BGMStart", 1.5f);
        Invoke("ShowLogo", 2f);
        Invoke("ShowButtons", 3f);
        Invoke("ShowBlurBG", 3.51f);
        // 隐藏对话框
        JumpScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
    }
    private void Update()
    {
        // Credits 界面
        if (InCredits)
        {
            CreditsScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                ExitCredits();
            }
        }
        else if (!InCredits) {
            CreditsScreen.SetActive(false);
        }

        // 彩蛋触发判定
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    if(EasterEggCount == 0)
        //    {
        //        EasterEggCount = 1;
        //    }
        //    else if(EasterEggCount == 8)
        //    {
        //        EasterEggCount = 0;
        //        SE_Ayashii.Play();
        //        InEasterEgg = 1;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    if (EasterEggCount == 1)
        //    {
        //        EasterEggCount = 2;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (EasterEggCount == 2)
        //    {
        //        EasterEggCount = 3;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    if (EasterEggCount == 3)
        //    {
        //        EasterEggCount = 4;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    if (EasterEggCount == 4)
        //    {
        //        EasterEggCount = 5;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    if (EasterEggCount == 5)
        //    {
        //        EasterEggCount = 6;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    if (EasterEggCount == 6)
        //    {
        //        EasterEggCount = 7;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (EasterEggCount == 7)
        //    {
        //        EasterEggCount = 8;
        //    }
        //    else
        //    {
        //        EasterEggCount = 0;
        //    }
        //}

        //if (InEasterEgg == 2)
        //{
        //    if(Input.GetKeyDown(KeyCode.Space))
        //    {
        //        OnConfirmExit();
        //    }
        //}
    }
    public void ShowLogo()
    {
        //BlurMenuBG.SetActive(true);
        MLAATLogo.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ChapSelect");
    }

    public void LookForCredits()
    {
        InCredits = true;
        TitleMusic.Stop();
        CreditMusic.Play();
    }
    public void ExitCredits()
    {
        ExitSFX.Play();
        CreditMusic.Stop();
        TitleMusic.Play();
        InCredits = false;
    }
    public void GonnaJump()
    {
        JumpScreen.SetActive(true);
        JumpScreen.GetComponent<Graphic>().CrossFadeAlpha(.99f, .25f, false);
        Invoke("ShowJumpPanel", .35f);
    }

    public void ShowJumpPanel()
    {
        JumpPanel.SetActive(true);
    }

    public void OnConfirmJump(string url)
    {
        if (url != "")
        {
            Application.OpenURL(url);
        }
        OnCancelJump();
    }
    public void OnCancelJump()
    {
        JumpScreen.SetActive(false);
        JumpScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        JumpPanel.SetActive(false);
    }
    public void DoorStart()
    {
        title_bg.Release();
        CourtDoorVideo.SetActive(true);
        CourtDoorVideo.GetComponent<VideoPlayer>().Play();
        CourtDoorSFX.Play();
    }
    public void BGMStart()
    {
        TitleMusic.Play();
    }
    public void ShowButtons()
    {
        ButtonsGroup.DOFade(1, 1f);
        ButtonsGroup.blocksRaycasts = true;
        ExitButton.DOFade(1, 1f);
        ExitButton.blocksRaycasts = true;
    }
    public void ShowBlurBG()
    {
        title_bg_iml3.SetActive(true);
        title_bg_iml3.GetComponent<Image>().DOFade(1, .5f);
    }
    // 结束游戏相关事件
    // 显示结束画面
    public void ShowExitScreen()
    {
        // 隐藏对话框
        ExitScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        ExitScreen.SetActive(true);
        ExitScreen.GetComponent<Graphic>().CrossFadeAlpha(.99f, .25f, false);
        Invoke("ShowExitPanel", .35f);
    }

    private void ShowExitPanel()
    {
        ExitPanel.SetActive(true);
    }

    public void OnConfirmExit()
    {
        //if (InEasterEgg == 1)
        //{
        //    OnCancelExit();
        //    CourtDoorVideo.SetActive(false);
        //    title_bg.Release();
        //    MLAATLogo.SetActive(false);
        //    ButtonsGroup.alpha = 0;
        //    ButtonsGroup.blocksRaycasts = false;
        //    TitleMusic.Stop();
        //    GeoMeGeoYouRT.Release();
        //    GeoMeGeoYouObject.SetActive(true);
        //    GeoMeGeoYouObject.GetComponent<VideoPlayer>().Play();
        //    InEasterEgg = 2;
        //    Invoke("OnConfirmExit", 90f);
        //}
        //else
        //{
        //    Debug.Log("退出游戏！");
        //    Application.Quit();
        //}
        Debug.Log("退出游戏！");
        Application.Quit();
    }

    // 取消退出
    public void OnCancelExit()
    {
        ExitScreen.SetActive(false);
        ExitScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        ExitPanel.SetActive(false);
    }
    public void ExitGameBtnSelEffect()
    {
        float time = .1f;
        DOTween.To(() => ExitGameBtnMask.GetComponent<RectMask2D>().padding, x => ExitGameBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time);
    }
    public void ExitGameBtnSelDeEffect()
    {
        float time = .1f;
        DOTween.To(() => ExitGameBtnMask.GetComponent<RectMask2D>().padding, x => ExitGameBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding224, time);
    }
}

