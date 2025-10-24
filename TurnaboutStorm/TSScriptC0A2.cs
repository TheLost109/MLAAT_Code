using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TSScriptC0A2 : MonoBehaviour
{
    // 游戏基础脚本
    public GameBaseController gameBaseController;
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 逆转风暴 - 贴图管理器
    public TSSpritesManager tsSpritesManager;
    // 逆转风暴 - 声音管理器
    public TSSoundsManager tsSoundsManager;
    // 法庭记录系统
    public CourtRecordsSystem courtRecordsSystem;
    // 对话文件
    public TextAsset DialogFile;
    // 主摄像机
    public GameObject MainCamera;

    // 点击后隐藏法庭记录
    public GameObject CourtRecordsHideOverlay;

    // Demo结束画面
    public GameObject DemoEndScreen;
    public GameObject DemoEndPanel;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }
    public void ProceedGame(int EventID, bool IsContinue)
    {
        if (tsMainScript.CurrentScript != "TSScriptC0A2")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A2";
            gameBaseController.SendMessage("ReadText", DialogFile);
            print(gameBaseController.EventID);
        }
        gameBaseController.DialogProcessing = true;
        Debug.Log("执行Event " + gameBaseController.EventID);
        // Area 2 初见暮光闪闪
        if (EventID == 0)
        {
            gameBaseController.TalkingSFXSpeed = 0.08f;
            gameBaseController.DialogIndex = 1;
            tsSpritesManager.NameTag.SetActive(false);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(false);
            tsSpritesManager.NewAreaText.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 1)
        {
            gameBaseController.DialogIndex = 2;
            tsSpritesManager.NameTag.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.SpeechText.SetActive(true);
            tsSpritesManager.NewAreaText.SetActive(false);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        // Area 1 成步堂接电话
        else if (EventID == 2)
        {
            gameBaseController.DialogIndex = 3;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 3)
        {
            gameBaseController.DialogIndex = 4;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 4)
        {
            gameBaseController.DialogIndex = 5;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 5)
        {
            gameBaseController.DialogIndex = 6;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 6)
        {
            gameBaseController.DialogIndex = 7;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 7)
        {
            gameBaseController.DialogIndex = 8;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            if (IsContinue)
            {
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                ProceedText(false, false);
                tsSoundsManager.SweatSFX.Play();
            }
        }
        else if (EventID == 8)
        {
            gameBaseController.DialogIndex = 9;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 9)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 10;
            if (IsContinue)
            {
                tsSpritesManager.dialogBox.SetActive(true);
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                tsSpritesManager.dialogBox.SetActive(false);
                tsSpritesManager.TwilightsBedroom.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.TwilightsBedroom.GetComponent<SpriteRenderer>().DOFade(1, 3f);
                gameBaseController.Clickable = false;
                Invoke("Event9Delay", 4f);
                Invoke("Event9Delay2", 4.15f);
            }
        }
        else if (EventID == 10)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 11;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (IsContinue)
            {
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(0, 0f);
                tsSpritesManager.TwilightStandNormal.GetComponent<SpriteRenderer>().DOFade(1, 1f);
                Invoke("Event10Delay", 2f);
            }
        }
        else if (EventID == 11)
        {
            gameBaseController.Clickable = false;
            gameBaseController.DialogIndex = 12;
            ProceedText(false, false);
            Invoke("Event11Delay", 2f);
        }
        else if (EventID == 12)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 13;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            if (IsContinue)
            {
                tsSpritesManager.dialogBox.SetActive(true);
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
            else if (!IsContinue)
            {
                Invoke("Event12Delay", 0.15f);
            }
        }
        else if (EventID == 13)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 14;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
            MusicUpdate("ChildOfMagic");
        }
        else if (EventID == 14)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 15;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
            MusicUpdate("ChildOfMagic");
        }
        else if (EventID == 15)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 16;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
            MusicUpdate("ChildOfMagic");
        }
        else if (EventID == 16)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 17;
            tsSpritesManager.dialogBox.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
            MusicUpdate("ChildOfMagic");
        }
        else if (EventID == 17)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.DialogIndex = 18;
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.Clickable = true;
            ProceedText(IsContinue, false);
            MusicUpdate("ChildOfMagic");
        }
        else if (EventID == 18)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.DialogIndex = 19;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.Clickable = false;
            tsSpritesManager.TwilightStandNormal.SetActive(false);
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            ProceedText(IsContinue, false);
            Invoke("Event18Delay", 2.2f);
            Invoke("Event18Delay2", 5f);
        }
        else if (EventID == 19)
        {
            tsSpritesManager.dialogBox.SetActive(false);
            tsSpritesManager.TwilightsBedroom.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
            tsSoundsManager.KickSFX.Play();
            Invoke("Event19Delay", .7f);
        }
        else if (EventID == 20)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandPanic.SetActive(true);
            gameBaseController.DialogIndex = 21;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 21)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandPanic.SetActive(true);
            gameBaseController.DialogIndex = 22;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 22)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandPanic.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.DialogIndex = 23;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 23)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.DialogIndex = 24;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 24)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.DialogIndex = 25;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 25)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            gameBaseController.DialogIndex = 26;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 26)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            gameBaseController.DialogIndex = 27;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 27)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitOops.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            gameBaseController.DialogIndex = 28;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 28)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            gameBaseController.DialogIndex = 29;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 29)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            gameBaseController.DialogIndex = 30;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 30)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                tsSoundsManager.KiriSFX.Play();
                tsSpritesManager.TwilightStandExplain.SetActive(false);
                tsSpritesManager.TwilightStandStartled.SetActive(true);
                tsSpritesManager.TwilightsBedroom.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
                Invoke("Event30Delay", 1f);
            }
            else if(IsContinue)
            {
                gameBaseController.Clickable = true;
                tsSpritesManager.TwilightStandWhat.SetActive(true);
            }
            gameBaseController.DialogIndex = 31;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 31)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            gameBaseController.DialogIndex = 32;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 32)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            gameBaseController.DialogIndex = 33;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 33)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            gameBaseController.DialogIndex = 34;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 34)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            gameBaseController.DialogIndex = 35;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 35)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitOops.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.DialogIndex = 36;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 36)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            gameBaseController.DialogIndex = 37;
            tsSpritesManager.dialogBox.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 37)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 38;
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, 0f);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(1, .3f);
                Invoke("Event37Delay", .3f);
            }
            else if(IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 38)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 39;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 39)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 40;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 40)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 41;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 41)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 42;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 42)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandWhat.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 43;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 43)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandWhat.SetActive(false);
            }
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 44;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 44)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandConfused.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 45;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 45)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandConfused.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 46;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 46)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 47;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 47)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 48;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 48)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 49;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 49)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 50;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 50)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 51;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 51)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                courtRecordsSystem.GetNewProfile(1);
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 52;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 52)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 53;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 53)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandExplain.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 54;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 54)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 55;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 55)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 56;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 56)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightStandExplain.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 57;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 57)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 58;
            if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(0, .3f);
                Invoke("Event57Delay", 1.3f);
            }
            else if (IsContinue)
            {
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 58)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 59;
            if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, 0);
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(1, .3f);
                Invoke("Event58Delay", 1.3f);
                Invoke("Event58Delay2", 3.5f);
                Invoke("Event58Delay3", 4.5f);
            }
            else if (IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(true);
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 59)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 60;
            tsSpritesManager.TheFilliesGuideToPonies.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            if (!IsContinue)
            {
                tsSoundsManager.ItemPopSFX.Play();
                gameBaseController.Clickable = false;
                Invoke("Event59Delay", 2f);
            }
            else if (IsContinue)
            {
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 60)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 61;
            tsSpritesManager.TheFilliesGuideToPonies.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSoundsManager.KickSFX.Play();
                tsSpritesManager.TwilightsBedroom.GetComponent<Transform>().DOShakePosition(.3f, new Vector3(2, 2, 0)).SetLoops(1, LoopType.Yoyo);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 61)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 62;
            tsSpritesManager.TheFilliesGuideToPonies.SetActive(true);
            tsSpritesManager.ItemHolder.SetActive(true);
            gameBaseController.Clickable = true;
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandHappy.SetActive(false);
            }
            tsSpritesManager.TwilightSitOops.SetActive(true);
            ProceedText(IsContinue, false);
        }
        else if (EventID == 62)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.dialogBox.SetActive(true);
            tsSpritesManager.NameTag.SetActive(false);
            gameBaseController.DialogIndex = 63;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            if (!IsContinue)
            {
                tsSoundsManager.NewRecordsSFX.Play();
                courtRecordsSystem.GetNewEvidence(2);
                courtRecordsSystem.NewEvidenceShow(2);
                tsSpritesManager.ItemHolder.SetActive(false);
                tsSpritesManager.TheFilliesGuideToPonies.SetActive(false);
                CourtRecordsHideOverlay.SetActive(true);
            }
            else if (IsContinue)
            {
                gameBaseController.Clickable = true;
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 63)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 64;
            tsSpritesManager.TwilightSitOops.SetActive(true);
            if (!IsContinue)
            {
                tsSpritesManager.NameTag.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 64)
        {
            BackgroundUpdate("TwilightsBedroom");
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 65;
            if (!IsContinue)
            {
                StopAllMusic();
                tsSoundsManager.AyashiiSFX.Play();
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.TwilightSitOops.SetActive(false);
                tsSpritesManager.TwilightSitSad.SetActive(true);
                tsSpritesManager.WhiteScreen.SetActive(true);
                tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .3f);
                Invoke("Event64Delay", .4f);
            }
            else if(IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(true);
            }
            ProceedText(IsContinue, false);
        }
        else if (EventID == 65)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 66;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 66)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 67;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 67)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 68;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 68)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 69;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 69)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 70;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 70)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 71;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 71)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 72;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 72)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 73;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 73)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 74;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 74)
        {
            gameBaseController.Clickable = false;
            gameBaseController.DialogIndex = 75;
            Invoke("Event74Delay", 1.4f);
            ProceedText(false, false);
        }
        else if (EventID == 75)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 76;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 76)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 77;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 77)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 78;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 78)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 79;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 79)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 80;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 80)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 81;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 81)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 82;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 82)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 83;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 83)
        {
            BackgroundUpdate("TwilightsBedroom");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 84;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 84)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightStandNormal.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 85;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 85)
        {
            BackgroundUpdate("TwilightsBedroom");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 86;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 86)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightSitSad.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 87;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 87)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightSitSad.SetActive(false);
            }
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 88;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 88)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 89;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 89)
        {
            BackgroundUpdate("TwilightsBedroom");
            MusicUpdate("ChildOfMagic");
            tsSpritesManager.TwilightStandHappy.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 90;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 90)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 91;
            if (!IsContinue)
            {
                StopAllMusic();
                tsSoundsManager.AyashiiSFX.Play();
                gameBaseController.Clickable = false;
                Invoke("Event90Delay", 2f);
            }
            else if (IsContinue)
            {
                gameBaseController.Clickable = true;
                tsSpritesManager.TwilightStandNormal.SetActive(true);
                ProceedText(true, false);
            }
        }
        else if (EventID == 91)
        {
            BackgroundUpdate("TwilightsBedroom");
            if (!IsContinue)
            {
                tsSpritesManager.TwilightStandNormal.SetActive(false);
            }
            tsSpritesManager.TwilightStandScared.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 92;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 92)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.TwilightStandScared.SetActive(true);
            gameBaseController.Clickable = true;
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 93;
            ProceedText(IsContinue, false);
        }
        else if (EventID == 93)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 94;
            ProceedText(IsContinue, false);
            if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                tsSpritesManager.TwilightStandScared.SetActive(false);
                tsSpritesManager.TwilightStandExplain.SetActive(true);
                Invoke("Event93Delay", 3.3f);
            }
            else if (IsContinue)
            {
                gameBaseController.Clickable = true;
                tsSpritesManager.TwilightStandHappy.SetActive(true);
            }
        }
        else if (EventID == 94)
        {
            BackgroundUpdate("TwilightsBedroom");
            tsSpritesManager.dialogBox.SetActive(true);
            gameBaseController.DialogIndex = 95;
            if (!IsContinue)
            {
                gameBaseController.Clickable = false;
                tsSpritesManager.TwilightStandHappy.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                Invoke("Event94Delay", 2f);
            }
            else if (IsContinue)
            {
                gameBaseController.Clickable = true;
                ProceedText(true, false);
            }
        }
        else if (EventID == 95)
        {
            gameBaseController.EventID = 94;
            tsSpritesManager.dialogBox.SetActive(false);
            gameBaseController.Clickable = false;
            tsSpritesManager.TwilightsBedroom.GetComponent<SpriteRenderer>().DOFade(0, 3f);
            Invoke("Event95Delay", 4f);
            Invoke("Event95Delay2", 4.6f);
        }
        //else if (EventID == 96)
        //{
        //    Debug.Log("Event "+ gameBaseController.EventID + "不存在，Event ID回滚至" + (gameBaseController.EventID - 1));
        //    gameBaseController.EventID = gameBaseController.EventID - 1;
        //}
    }
    public void ClearAllBG()
    {
        tsSpritesManager.TwilightsBedroom.SetActive(false);
        gameBaseController.CurrentBG = "";
    }
    public void BackgroundUpdate(string NewBG)
    {
        string CurrentBG = gameBaseController.CurrentBG;
        if (CurrentBG != NewBG)
        {
            gameBaseController.CurrentBG = NewBG;
            if (NewBG == "TwilightsBedroom")
            {
                ClearAllBG();
                tsSpritesManager.TwilightsBedroom.SetActive(true);
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
        tsSoundsManager.ChildOfMagic.Stop();
    }

    public void MusicUpdate(string NewMusicName)
    {
        if (gameBaseController.CurrentMusic != NewMusicName)
        {
            if(NewMusicName == "ChildOfMagic")
            {
                gameBaseController.CurrentMusic = "ChildOfMagic";
                tsSoundsManager.ChildOfMagic.Play();
            }
            else if (gameBaseController.CurrentMusic == "")
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
    public void Event9Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(true);
    }
    public void Event9Delay2()
    {
        tsSoundsManager.BikkuriSFX.Play();
        tsSpritesManager.WhiteScreen.SetActive(false);
        tsSpritesManager.dialogBox.SetActive(true);
        gameBaseController.Clickable = true;
        ProceedText(false, false);
    }
    public void Event10Delay()
    {
        tsSoundsManager.AyashiiSFX.Play();
        ProceedText(false, false);
        gameBaseController.Clickable = true;
    }
    public void Event11Delay()
    {
        gameBaseController.EventID = 12;
        gameBaseController.Proceed = true;
        tsSpritesManager.WhiteScreen.SetActive(true);
    }
    public void Event12Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
        MainCamera.GetComponent<Camera>().DOShakePosition(.3f, new Vector3(2, 0, 0)).SetLoops(1, LoopType.Yoyo);
        tsSoundsManager.DamageSFX.Play();
        ProceedText(false, false);
        gameBaseController.Clickable = true;
    }
    public void Event18Delay()
    {
        tsSpritesManager.TwilightStandConfused.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
    }
    public void Event18Delay2()
    {
        gameBaseController.EventID = 19;
        gameBaseController.Proceed = true;
    }
    public void Event19Delay()
    {
        tsSpritesManager.dialogBox.SetActive(true);
        gameBaseController.DialogIndex = 20;
        gameBaseController.Clickable = true;
        ProceedText(false, false);
    }
    public void Event30Delay()
    {
        tsSpritesManager.TwilightStandStartled.SetActive(false);
        tsSpritesManager.TwilightStandWhat.SetActive(true);
        gameBaseController.Clickable = true;
    }
    public void Event37Delay()
    {
        tsSoundsManager.AyashiiSFX.Play();
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
        tsSpritesManager.WhiteScreen.GetComponent<Image>().DOFade(0, .3f);
        tsSpritesManager.WhiteScreen.SetActive(false);
        ProceedText(false, false);
    }
    public void Event57Delay()
    {
        gameBaseController.Clickable = true;
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.TwilightStandExplain.GetComponent<SpriteRenderer>().DOFade(1, 0f);
        ProceedText(false, false);
    }
    public void Event58Delay()
    {
        tsSoundsManager.AyashiiSFX.Play();
        ProceedText(false, false);
    }
    public void Event58Delay2()
    {
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandConfused.SetActive(true);
    }
    public void Event58Delay3()
    {
        gameBaseController.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(true);
        tsSpritesManager.TwilightStandConfused.SetActive(false);
    }
    public void Event59Delay()
    {
        gameBaseController.Clickable = true;
        ProceedText(false, false);
    }
    public void Event64Delay()
    {
        tsSpritesManager.WhiteScreen.SetActive(false);
    }
    public void Event74Delay()
    {
        gameBaseController.EventID = 75;
        gameBaseController.Proceed = true;
    }
    public void Event90Delay()
    {
        gameBaseController.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        tsSpritesManager.TwilightStandNormal.SetActive(true);
        ProceedText(false, false);
    }
    public void Event93Delay()
    {
        gameBaseController.Clickable = true;
        tsSpritesManager.TwilightStandExplain.SetActive(false);
        tsSpritesManager.TwilightStandHappy.SetActive(true);
    }
    public void Event94Delay()
    {
        gameBaseController.Clickable = true;
        tsSpritesManager.TwilightStandHappy.SetActive(false);
        ProceedText(false, false);
    }
    public void Event95Delay()
    {
        ClearAllBG();
        tsSoundsManager.JingleGS1.Play();
        DemoEndScreen.GetComponent<Image>().DOFade(0, 0f);
        DemoEndScreen.SetActive(true);
        DemoEndScreen.GetComponent<Image>().DOFade(1, .5f);
    }
    public void Event95Delay2()
    {
        DemoEndPanel.SetActive(true);
    }
}
