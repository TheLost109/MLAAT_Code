using UnityEngine;
using DG.Tweening;

public class TSScriptC0A1 : MonoBehaviour
{
    // 游戏基础脚本
    public GameBaseController gameBaseController;
    // 逆转风暴 - 基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 逆转风暴 - 声音管理器
    public TSSoundsManager tsSoundsManager;
    // 对话文件
    public TextAsset DialogFile;
    // 主摄像机
    public GameObject MainCamera;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ClearAllBG()
    {
        tsSpritesManager.OfficeBG.SetActive(false);
    }

    private void PickUp()
    {
        tsSoundsManager.RingtonePW.Stop();
        tsSoundsManager.PickUpSFX.Play();
    }

    private void ItemPop()
    {
        tsSpritesManager.ItemHolder.SetActive(true);
        tsSpritesManager.WrightPhoneSpr.SetActive(true);
        tsSoundsManager.ItemPopSFX.Play();
    }
    private void WrightAnswer()
    {
        tsSpritesManager.NameTag.SetActive(true);
        tsSpritesManager.dialogBox.SetActive(true);
        gameBaseController.EventID = 2;
        ProceedGame(gameBaseController.EventID, false);
    }

    public void ProceedGame(int EventID, bool IsContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A1")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A1";
            gameBaseController.SendMessage("ReadText", DialogFile);
            print(gameBaseController.EventID);
        }
        gameBaseController.DialogProcessing = true;
        print(gameBaseController.EventID);
        if (EventID == 0)
        {
            Debug.Log("执行Event 0");
            gameBaseController.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        // Area 1 成步堂来电
        else if (EventID == 1)
        {
            Debug.Log("执行Event 1");
            tsSpritesManager.OfficeBG.GetComponent<SpriteRenderer>().DOFade(0, 0);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.OfficeBG.GetComponent<SpriteRenderer>().DOFade(1, 3f);
            gameBaseController.Clickable = false;
            tsSpritesManager.NewAreaText.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.SpeechText.SetActive(true);
            tsSoundsManager.RingtonePW.Play();
            Invoke("PickUp", 8f);
            Invoke("ItemPop", 9f);
            Invoke("WrightAnswer", 10f);
        }
        // Area 1 成步堂接电话
        else if (EventID == 2)
        {
            Debug.Log("执行Event 2");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.WrightPhoneSpr.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 2;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 3)
        {
            Debug.Log("执行Event 3");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.WrightPhoneSpr.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 3;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 4)
        {
            Debug.Log("执行Event 4");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.ItemHolder.SetActive(true);
            tsSpritesManager.WrightPhoneSpr.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 4;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 5)
        {
            Debug.Log("执行Event 5");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 5;
            if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                Invoke("Event5Delay", 1f);
                Invoke("Event5Delay2", 2f);
            }
            else if(IsContinue)
            {
                ProceedText(true, false);
                gameBaseController.Clickable = true;
            }
        }
        else if (EventID == 6)
        {
            Debug.Log("执行Event 6");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 6;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 7)
        {
            Debug.Log("执行Event 7");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 7;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 8)
        {
            Debug.Log("执行Event 8");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 8;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 9)
        {
            Debug.Log("执行Event 9");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 9;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 10)
        {
            Debug.Log("执行Event 10");
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 10;
            ProceedText(IsContinue, false);
            gameBaseController.Clickable = true;
        }
        else if (EventID == 11)
        {
            Debug.Log("执行Event 11");
            tsSpritesManager.dialogBox.SetActive(true);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            gameBaseController.DialogIndex = 11;
            if (IsContinue)
            {
                ProceedText(true, false);
                gameBaseController.Clickable = true;
                MusicUpdate("Suspense");
            }
            else if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                ProceedText(false, false);
                Invoke("Event11Delay", 1f);
                Invoke("Event11Delay2", 2f);
            }
        }
        else if (EventID == 12)
        {
            Debug.Log("执行Event 12");
            tsSpritesManager.dialogBox.SetActive(true);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            gameBaseController.DialogIndex = 12;
            if (IsContinue)
            {
                ProceedText(true, false);
                gameBaseController.Clickable = true;
                MusicUpdate("Suspense");
            }
            else if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                ProceedText(false, false);
                Invoke("Event12Delay", 1f);
                Invoke("Event12Delay2", 1.2f);
                Invoke("Event12Delay3", 2.2f);
            }
        }
        else if (EventID == 13)
        {
            Debug.Log("执行Event 13");
            tsSpritesManager.dialogBox.SetActive(true);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            gameBaseController.DialogIndex = 13;
            gameBaseController.Clickable = true;
            if (IsContinue)
            {
                ProceedText(true, false);
                MusicUpdate("Suspense");
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
            }
        }
        else if (EventID == 14)
        {
            Debug.Log("执行Event 14");
            tsSpritesManager.dialogBox.SetActive(true);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            gameBaseController.DialogIndex = 14;
            gameBaseController.Clickable = true;
            if (IsContinue)
            {
                ProceedText(true, false);
                MusicUpdate("Suspense");
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
            }
        }
        else if (EventID == 15)
        {
            Debug.Log("执行Event 15");
            tsSpritesManager.dialogBox.SetActive(true);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            gameBaseController.DialogIndex = 15;
            gameBaseController.Clickable = true;
            gameBaseController.TalkingSFXSpeed = 0.16f;
            Invoke("Event15Delay", .1f);
            if (IsContinue)
            {
                ProceedText(true, false);
                MusicUpdate("Suspense");
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
            }
        }
        else if (EventID == 16)
        {
            Debug.Log("执行Event 16");
            tsSpritesManager.dialogBox.SetActive(false);
            BackgroundUpdate(gameBaseController.CurrentBG, "WrightOffice");
            gameBaseController.Clickable = false;
            Invoke("Event16Delay", 3f);
            Invoke("Event16Delay2", 8f);
        }
    }
    public void BackgroundUpdate(string CurrentBG, string NewBG)
    {
        if (CurrentBG != NewBG)
        {
            gameBaseController.CurrentBG = NewBG;
            if (NewBG == "WrightOffice")
            {
                ClearAllBG();
                tsSpritesManager.OfficeBG.SetActive(true);
            }
            else
            {
                ClearAllBG();
            }
        }
    }

    public void StopAllMusic()
    {
        gameBaseController.CurrentMusic = "";
        tsSoundsManager.Suspense.Stop();
    }

    public void MusicUpdate(string NewMusicName)
    {
        if (gameBaseController.CurrentMusic != NewMusicName)
        {
            if(NewMusicName == "Suspense")
            {
                gameBaseController.CurrentMusic = "Suspense";
                tsSoundsManager.Suspense.Play();
            }
            else if(gameBaseController.CurrentMusic == "")
            {
                StopAllMusic();
            }
        }
    }

    public void ProceedText(bool IsContinue, bool SpriteTalk)
    {
        if (!IsContinue)
        {
            gameBaseController.ShowDialogRow();
            if (SpriteTalk) gameBaseController.IsCharacterTalking = true;
        }
        else
        {
            gameBaseController.UpdateText();
        }
    }
    public void Event5Delay()
    {
        tsSpritesManager.ItemHolder.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), .5f);
        tsSoundsManager.ItemVanishSFX.Play();
    }
    public void Event5Delay2()
    {
        tsSpritesManager.ItemHolder.SetActive(false);
        tsSpritesManager.WrightPhoneSpr.SetActive(false);
        ProceedText(false, false);
        gameBaseController.Clickable = true;
    }
    public void Event11Delay()
    {
        MainCamera.GetComponent<Camera>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
        tsSoundsManager.ExplodeSFX.Play();
        MusicUpdate("Suspense");
    }
    public void Event11Delay2()
    {
        gameBaseController.Clickable = true;
    }
    public void Event12Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
        Invoke("FlashbangOut", .2f);
        tsSoundsManager.ExplodeSFX.Play();
    }
    public void Event12Delay2()
    {
        MainCamera.GetComponent<Camera>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
        gameBaseController.Clickable = true;
    }
    public void Event12Delay3()
    {
        gameBaseController.Clickable = true;
    }
    public void FlashbangOut()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
    }
    public void Event15Delay()
    {
        tsSpritesManager.OfficeBG.GetComponent<SpriteRenderer>().DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo);
    }
    public void Event16Delay()
    {
        BackgroundUpdate(gameBaseController.CurrentBG, "none");
        tsSoundsManager.KickSFX.Play();
        tsSoundsManager.SuspenseIntroFade.FadeOut();
        tsSoundsManager.SuspenseLoopFade.FadeOut();
    }
    public void Event16Delay2()
    {
        gameBaseController.AreaID = 2;
        gameBaseController.EventID = 0;
        tsMainScript.ProceedGame(gameBaseController.ChapterID, gameBaseController.AreaID, false);
    }
}
