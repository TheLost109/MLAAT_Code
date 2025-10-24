using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapSelectScripts : MonoBehaviour
{
    public SettingsPanelScript settingsPanelScript;
    public AudioSource ExitSFX;
    public GameObject TSBeginObj;
    public GameObject TSBeginLogo;
    public GameObject LoadScreen;
    public GameObject LoadPanel;
    public GameObject LoadSuccess;
    public GameObject TransitionQ;
    public GameObject TransitionE;
    public GameObject TSPanel;
    public GameObject MLIPanel;
    public GameObject EoJPanel;
    public GameObject MuseumPanel;
    public GameObject OrchestraScreen;
    public GameObject OrchestraNav;
    // 音频相关
    public AudioWithIntro TSMusic;
    public AudioWithIntro MLIMusic;
    public AudioWithIntro EoJMusic;
    public AudioWithIntro MuseumMusicMelody;
    public AudioWithIntro MuseumMusicRhythm;
    public MusicFade MuseumMusicMelodyClipIntro;
    public MusicFade MuseumMusicMelodyClipLoop;
    public AudioSource CursorSFX;
    public AudioSource OpenMenuSFX;

    // 底部导航
    public GameObject BottomNav;
    public GameObject BottomNavGrad;

    private int CurrentGame = -1;
    private int OnTransition = 0;

    private int InAlertPage = 0;
    public bool InAnimStudio = false;
    private bool InOrchestra = false;
    private bool InEpisodes = false;
    private bool EnteringGame = false;

    // 交响乐团大厅
    private string CurrentMusic = "None";
    public TMP_Text MusicAlbum;
    public TMP_Text MusicArtist;
    public AudioWithIntro PWObjection2001;
    public AudioSource MayaFey2001;
    public AudioWithIntro WaitASecond;
    public AudioSource WaitASecond_intro;
    public AudioSource WaitASecond_loop;
    public GameObject Music1Checkmark;
    public GameObject Music2Checkmark;
    public GameObject Music3Checkmark;
    public GameObject GyakutenSaibanSoundBox;
    public GameObject TrueBlueScootaloo;
    private AssetBundle MLIBGM;

    // BGM显示
    public string BGMName = "None";
    public GameObject BGMNameArea;
    public TMP_Text BGMNameText;

    // 进场动画
    public GameObject EnterAnim;

    // 按钮交互动画
    public Vector4 BtnMaskPadding0;
    public Vector4 BtnMaskPadding441;
    public GameObject TSStartGameBtnMask;
    public GameObject TSContinueBtnMask;
    public GameObject TSEpisodesBtnMask;
    public GameObject MLIComingSoonBtnMask;
    public GameObject EoJComingSoonBtnMask;
    public GameObject OrchestraHallBtnMask;
    public GameObject ArtLibraryBtnMask;
    public GameObject AnimStudioBtnMask;

    // 选择章节
    public GameObject Episodes;
    public GameObject EpisodesNavGrad;
    public GameObject EpisodesNav;
    public GameObject EpisodesTS;

    public GameObject SceneCanvas;

    //
    public GameObject MuseumLogo;
    public GameObject MuseumLogoZH;

    private void Awake()
    {

    }
    private void Start()
    {
        EnteringGame = true;
        LoadScreen.GetComponent<Graphic>().CrossFadeAlpha(0, 0, false);
        LoadSuccess.GetComponent<Graphic>().CrossFadeAlpha(0, 0, false);
        CurrentGame = 0;
        Invoke("PlayEnterAnim", 1f);
    }

    private void Update()
    {
        if(settingsPanelScript.Hided == 0 || EnteringGame == true || InOrchestra || InEpisodes)
        {
            BottomNav.SetActive(false);
        }
        // 调整返回操作优先级
        if (settingsPanelScript.Hided == 1 && InAlertPage == 0 && EnteringGame == false)
        {
            if (!InAnimStudio && !InOrchestra && !InEpisodes)
            {
                BottomNav.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    BacktoMenu();
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    settingsPanelScript.SendMessage("OpenSettings");
                    OpenMenuSFX.Play();
                }
                // 切换游戏Q
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SwitchGameQ();
                }
                // 切换游戏E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SwitchGameE();
                }
            }
            if (InOrchestra)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    ExitOrchestra();
                }
            }
        }

        if(CurrentMusic == "None")
        {
            ClearMusicCheckmarks();
            ClearAllAlbums();
            MusicAlbum.text = "";
            MusicArtist.text = "";
        }
        else if(CurrentMusic == "PWObjection2001")
        {
            Music1Checkmark.SetActive(true);
            ClearAllAlbums();
            GyakutenSaibanSoundBox.SetActive(true);
            MusicAlbum.text = "专辑：逆转裁判 SOUND BOX";
            MusicArtist.text = "艺术家：杉森雅和";
        }
        else if (CurrentMusic == "MayaFey2001")
        {
            Music2Checkmark.SetActive(true);
            ClearAllAlbums();
            GyakutenSaibanSoundBox.SetActive(true);
            MusicAlbum.text = "专辑：逆转裁判 SOUND BOX";
            MusicArtist.text = "艺术家：杉森雅和";
        }
        else if (CurrentMusic == "WaitASecond")
        {
            Music3Checkmark.SetActive(true);
            ClearAllAlbums();
            TrueBlueScootaloo.SetActive(true);
            MusicAlbum.text = "专辑：True Blue Scootaloo ~ The Music Behind the Mystery";
            MusicArtist.text = "艺术家：Trot Pilgrim";
        }

        if (BGMName == "None")
        {
            BGMNameText.text = "";
            BGMNameArea.SetActive(false);
        }
        else
        {
            BGMNameText.text = BGMName;
            BGMNameArea.SetActive(true);
        }

        if(CurrentGame == 0)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 王泥喜法介 ~ 新章开庭!";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Apollo Justice ~ A New Era Begins!";
            }
        }
        else if(CurrentGame == 1)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 等一下! ~ 真相之闪光";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Wait A Second! ~ A Spark of Truth";
            }
        }
        else if (CurrentGame == 2)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 王泥喜法介 ~ 新章开庭! 2013";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Apollo Justice ~ A New Era Begins! 2013";
            }
        }
        else if (CurrentGame == 3)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                BGMName = "♪ 王泥喜法介 ~ 新章开庭! 2024";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                BGMName = "♪ Apollo Justice ~ A New Era Begins! 2024";
            }
        }
        else
        {
            BGMName = "";
        }
        // Episodes
        if (InEpisodes)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                ExitEpisodes();
            }
        }
        //
        if (InAnimStudio)
        {
            SceneCanvas.SetActive(false);
        }
        else if (!InAnimStudio)
        {
            SceneCanvas.SetActive(true);
        }
        // 美术馆Logo
        if (SettingsScript.Instance.Language == "Chinese")
        {
            MuseumLogo.SetActive(false);
            MuseumLogoZH.SetActive(true);
        }
        else
        {
            MuseumLogo.SetActive(true);
            MuseumLogoZH.SetActive(false);
        }
    }
    public void PlayEnterAnim()
    {
        EnterAnim.SetActive(true);
        TSPanel.SetActive(true);
        Invoke("ShowTSPanel", 1f);
        Invoke("ExitEnterAnim", 2.92f);
    }
    public void ExitEnterAnim()
    {
        EnterAnim.SetActive(false);
        EnteringGame = false;
    }
    public void ShowTSPanel()
    {
        TSPanel.SetActive(true);
        EpisodesTS.SetActive(true);
    }
    public void BeginTS()
    {
        EnteringGame = true;
        TSBeginObj.SetActive(true);
        Invoke("ShowTSLogo", 1f);
        Invoke("LoadTSScene", 7f);
    }
    public void LoadTSScene()
    {
        SceneManager.LoadScene("TSGame");
    }
    public void ShowTSLogo()
    {
        TSBeginLogo.SetActive(true);
    }
    public void BacktoMenu()
    {
        ExitSFX.Play();
        SceneManager.LoadScene("Menu");
    }
    public void ShowLoadScreen()
    {
        LoadScreen.SetActive(true);
        LoadScreen.GetComponent<Graphic>().CrossFadeAlpha(.99f, .25f, false);
        Invoke("ShowLoadPanel", .35f);
        InAlertPage = 1;
    }

    private void ShowLoadPanel()
    {
        LoadPanel.SetActive(true);
    }
    public void OnCancelLoad()
    {
        LoadScreen.SetActive(false);
        LoadScreen.GetComponent<Graphic>().CrossFadeAlpha(0f, 0f, false);
        LoadPanel.SetActive(false);
        InAlertPage = 0;
    }

    public void SwitchGameQ()
    {
        if (OnTransition == 0)
        {
            OnTransition = 1;
            TransitionQ.SetActive(true);
            CursorSFX.Play();
            Invoke("HideEpisodes", .25f);
            if (CurrentGame == 0)
            {
                CurrentGame = 3;
                TSMusic.Stop();
                MuseumMusicMelody.Play();
                MuseumMusicRhythm.Play();
                Invoke("CloseTS", .25f);
                Invoke("OpenMuseum", .75f);
            }
            else if (CurrentGame == 1)
            {
                CurrentGame = 0;
                MLIMusic.Stop();
                TSMusic.Play();
                Invoke("CloseMLI", .25f);
                Invoke("OpenTS", .75f);
            }
            else if (CurrentGame == 2)
            {
                CurrentGame = 1;
                EoJMusic.Stop();
                MLIMusic.Play();
                Invoke("CloseEoJ", .25f);
                Invoke("OpenMLI", .75f);
            }
            else if (CurrentGame == 3)
            {
                CurrentGame = 2;
                MuseumMusicMelody.Stop();
                MuseumMusicRhythm.Stop();
                EoJMusic.Play();
                Invoke("CloseMuseum", .25f);
                Invoke("OpenEoJ", .75f);
            }
            Invoke("DisplayEpisodes", .75f);
            Invoke("TransQEnd", 1f);
        }
    }
    public void SwitchGameE()
    {
        if (OnTransition == 0)
        {
            OnTransition = 1;
            TransitionE.SetActive(true);
            CursorSFX.Play();
            Invoke("HideEpisodes", .25f);
            if (CurrentGame == 0)
            {
                CurrentGame = 1;
                TSMusic.Stop();
                MLIMusic.Play();
                Invoke("CloseTS", .25f);
                Invoke("OpenMLI", .75f);
            }
            else if (CurrentGame == 1)
            {
                CurrentGame = 2;
                MLIMusic.Stop();
                EoJMusic.Play();
                Invoke("CloseMLI", .25f);
                Invoke("OpenEoJ", .75f);
            }
            else if (CurrentGame == 2)
            {
                CurrentGame = 3;
                EoJMusic.Stop();
                MuseumMusicMelody.Play();
                MuseumMusicRhythm.Play();
                Invoke("CloseEoJ", .25f);
                Invoke("OpenMuseum", .75f);
            }
            else if (CurrentGame == 3)
            {
                CurrentGame = 0;
                MuseumMusicMelody.Stop();
                MuseumMusicRhythm.Stop();
                TSMusic.Play();
                Invoke("CloseMuseum", .25f);
                Invoke("OpenTS", .75f);
            }
            Invoke("DisplayEpisodes", .75f);
            Invoke("TransEEnd", 1f);
        }
    }
    private void CloseTS()
    {
        TSPanel.SetActive(false);
    }
    private void OpenTS()
    {
        TSPanel.SetActive(true);
    }
    private void CloseMLI()
    {
        MLIPanel.SetActive(false);
    }
    private void OpenMLI()
    {
        MLIPanel.SetActive(true);
    }
    private void CloseEoJ()
    {
        EoJPanel.SetActive(false);
    }
    private void OpenEoJ()
    {
        EoJPanel.SetActive(true);
    }
    private void CloseMuseum()
    {
        MuseumPanel.SetActive(false);
    }
    private void OpenMuseum()
    {
        MuseumPanel.SetActive(true);
    }
    private void TransQEnd()
    {
        TransitionQ.SetActive(false);
        OnTransition = 0;
    }
    private void TransEEnd()
    {
        TransitionE.SetActive(false);
        OnTransition = 0;
    }

    public void GoAnimStudio()
    {
        MuseumMusicMelodyClipIntro.FadeOut();
        MuseumMusicMelodyClipLoop.FadeOut();
        SceneManager.LoadScene("AnimStudio", LoadSceneMode.Additive);
        // 改变底部导航
        InAnimStudio = true;
    }
    //public void ExitAnimStudio()
    //{
    //    MuseumPanel.SetActive(true);
    //    MuseumMusicMelodyClipIntro.FadeIn();
    //    MuseumMusicMelodyClipLoop.FadeIn();
    //    ExitSFX.Play();
    //    SceneManager.UnloadSceneAsync("AnimStudio");
    //    // 改变底部导航
    //    InAnimStudio = 0;
    //}
    public void GoToOrchestra()
    {
        MuseumPanel.SetActive(false);
        OrchestraScreen.SetActive(true);
        OrchestraNav.SetActive(true);
        BottomNavGrad.SetActive(false);
        MuseumMusicMelodyClipIntro.FadeOut();
        MuseumMusicMelodyClipLoop.FadeOut();
        // 改变底部导航
        InOrchestra = true;
        // 加载MLI音乐AB包
        MLIBGM = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/mli/case1/bgm.unity3d");
        WaitASecond.introClip = (AudioClip)MLIBGM.LoadAsset("Wait_A_SecondA", typeof(AudioClip));
        WaitASecond.loopClip = (AudioClip)MLIBGM.LoadAsset("Wait_A_SecondB", typeof(AudioClip));
        WaitASecond_intro.resource = (AudioClip)MLIBGM.LoadAsset("Wait_A_SecondA", typeof(AudioClip));
        WaitASecond_loop.resource = (AudioClip)MLIBGM.LoadAsset("Wait_A_SecondB", typeof(AudioClip));
    }
    public void ExitOrchestra()
    {
        MuseumPanel.SetActive(true);
        OrchestraScreen.SetActive(false);
        OrchestraNav.SetActive(false);
        BottomNavGrad.SetActive(true);
        StopAllMusic();
        MuseumMusicRhythm.UnMute();
        MuseumMusicMelodyClipIntro.FadeIn();
        MuseumMusicMelodyClipLoop.FadeIn();
        ExitSFX.Play();
        // 改变底部导航
        InOrchestra = false;
        // 卸载MLI音乐AB包
        MLIBGM.Unload(true);
    }
    public void StopAllMusic()
    {
        CurrentMusic = "None";
        MuseumMusicRhythm.Mute();
        PWObjection2001.Stop();
        MayaFey2001.Stop();
        WaitASecond.Stop();
    }
    public void PlayMusic(string MusicName)
    {
        StopAllMusic();
        ClearMusicCheckmarks();
        if (MusicName == "MayaFey2001")
        {
            CurrentMusic = "MayaFey2001";
            MayaFey2001.Play();
        }
        else if(MusicName == "PWObjection2001")
        {
            CurrentMusic = "PWObjection2001";
            PWObjection2001.Play();
        }
        else if (MusicName == "WaitASecond")
        {
            CurrentMusic = "WaitASecond";
            WaitASecond.Play();
        }
    }
    public void ClearMusicCheckmarks()
    {
        Music1Checkmark.SetActive(false);
        Music2Checkmark.SetActive(false);
        Music3Checkmark.SetActive(false);
    }

    public void GoToTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void BtnSelEffect(string BtnName)
    {
        float time = .2f;
        if (BtnName == "TSNewGame")
        {
            DOTween.Kill("TSStartGameBtn");
            TSStartGameBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSStartGameBtnMask.SetActive(true);
            DOTween.To(() => TSStartGameBtnMask.GetComponent<RectMask2D>().padding, x => TSStartGameBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSStartGameBtn");
        }
        else if(BtnName == "TSContinue")
        {
            DOTween.Kill("TSContinueBtn");
            TSContinueBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSContinueBtnMask.SetActive(true);
            DOTween.To(() => TSContinueBtnMask.GetComponent<RectMask2D>().padding, x => TSContinueBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSContinueBtn");
        }
        else if (BtnName == "TSEpisodes")
        {
            DOTween.Kill("TSEpisodesBtn");
            TSEpisodesBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSEpisodesBtnMask.SetActive(true);
            DOTween.To(() => TSEpisodesBtnMask.GetComponent<RectMask2D>().padding, x => TSEpisodesBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSEpisodesBtn");
        }
        else if (BtnName == "MLIComingSoon")
        {
            DOTween.Kill("MLIComingSoonBtn");
            MLIComingSoonBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            MLIComingSoonBtnMask.SetActive(true);
            DOTween.To(() => MLIComingSoonBtnMask.GetComponent<RectMask2D>().padding, x => MLIComingSoonBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("MLIComingSoonBtn");
        }
        else if (BtnName == "EoJComingSoon")
        {
            DOTween.Kill("EoJComingSoonBtn");
            EoJComingSoonBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            EoJComingSoonBtnMask.SetActive(true);
            DOTween.To(() => EoJComingSoonBtnMask.GetComponent<RectMask2D>().padding, x => EoJComingSoonBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("EoJComingSoonBtn");
        }
        else if (BtnName == "OrchestraHall")
        {
            DOTween.Kill("OrchestraHallBtn");
            OrchestraHallBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            OrchestraHallBtnMask.SetActive(true);
            DOTween.To(() => OrchestraHallBtnMask.GetComponent<RectMask2D>().padding, x => OrchestraHallBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("OrchestraHallBtn");
        }
        else if (BtnName == "ArtLibrary")
        {
            DOTween.Kill("ArtLibraryBtn");
            ArtLibraryBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            ArtLibraryBtnMask.SetActive(true);
            DOTween.To(() => ArtLibraryBtnMask.GetComponent<RectMask2D>().padding, x => ArtLibraryBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("ArtLibraryBtn");
        }
        else if (BtnName == "AnimStudio")
        {
            DOTween.Kill("AnimStudioBtn");
            AnimStudioBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            AnimStudioBtnMask.SetActive(true);
            DOTween.To(() => AnimStudioBtnMask.GetComponent<RectMask2D>().padding, x => AnimStudioBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("AnimStudioBtn");
        }
    }
    public void BtnSelDeEffect(string BtnName)
    {
        if (BtnName == "TSNewGame")
        {
            TSStartGameBtnMask.SetActive(false);
        }
        else if (BtnName == "TSContinue")
        {
            TSContinueBtnMask.SetActive(false);
        }
        else if (BtnName == "TSEpisodes")
        {
            TSEpisodesBtnMask.SetActive(false);
        }
        else if (BtnName == "MLIComingSoon")
        {
            MLIComingSoonBtnMask.SetActive(false);
        }
        else if (BtnName == "EoJComingSoon")
        {
            EoJComingSoonBtnMask.SetActive(false);
        }
        else if (BtnName == "OrchestraHall")
        {
            OrchestraHallBtnMask.SetActive(false);
        }
        else if (BtnName == "ArtLibrary")
        {
            ArtLibraryBtnMask.SetActive(false);
        }
        else if (BtnName == "AnimStudio")
        {
            AnimStudioBtnMask.SetActive(false);
        }
    }

    public void EnterEpisodes()
    {
        InEpisodes = true;
        Episodes.GetComponent<RectTransform>().DOLocalMoveY(-323, .5f);
        Episodes.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //BottomNav.SetActive(false);
        BottomNavGrad.SetActive(false);
        EpisodesNav.SetActive(true);
        EpisodesNavGrad.SetActive(true);
    }
    public void ExitEpisodes()
    {
        InEpisodes = false;
        Episodes.GetComponent<RectTransform>().DOLocalMoveY(-352, .5f);
        Episodes.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //BottomNav.SetActive(true);
        BottomNavGrad.SetActive(true);
        EpisodesNav.SetActive(false);
        EpisodesNavGrad.SetActive(false);
        ExitSFX.Play();
    }
    public void DisplayEpisodes()
    {
        if (CurrentGame == 0)
        {
            EpisodesTS.SetActive(true);
        }
        else
        {
            EpisodesTS.SetActive(false);
        }
        Episodes.SetActive(true);
    }
    public void HideEpisodes()
    {
        Episodes.SetActive(false);
    }

    public void ClearAllAlbums()
    {
        GyakutenSaibanSoundBox.SetActive(false);
        TrueBlueScootaloo.SetActive(false);
    }
}
