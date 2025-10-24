using UnityEngine;
using UnityEngine.Video;

public class TSScriptC0A0 : MonoBehaviour
{
    // 游戏基础脚本
    public GameBaseController gameBaseController;
    // 逆转风暴基础脚本
    public TSMainScript tsMainScript;
    // 法庭记录脚本
    public CourtRecordsSystem courtRecordsSystem;
    // 对话文件
    public TextAsset DialogFile;
    // 对话框
    public GameObject dialogBox;
    // 对话框上名称标签
    public GameObject NameTag;
    // 对话文本
    public GameObject SpeechText;
    // Area 0 开幕
    public AudioSource IntroMusic;
    public GameObject IntroVideo;
    // RenderTexture
    public RenderTexture ts_prologue;

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void ProceedGame()
    {
        if(tsMainScript.CurrentScript != "TSScriptC0A0")
        {
            // 读取 TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A0";
            gameBaseController.SendMessage("ReadText", DialogFile);
            print(gameBaseController.EventID);
        }
        gameBaseController.DialogProcessing = true;
        Debug.Log("已读取对话文本0");
        // 开场
        Begin0();
    }

    private void Begin0()
    {
        courtRecordsSystem.GetNewEvidence(0);
        courtRecordsSystem.GetNewEvidence(1);
        courtRecordsSystem.GetNewProfile(0);
        NameTag.SetActive(false);
        gameBaseController.Clickable = false;
        PlayPrologue();
        Invoke("showBox", 7f);
        Invoke("dialog", 7f);
        Invoke("dialog", 12f);
        Invoke("dialog", 17f);
        Invoke("dialog", 22f);
        Invoke("dialog", 27f);
        Invoke("dialog", 31f);
        Invoke("dialog", 34f);
        Invoke("hideBox", 37f);
        Invoke("End0", 45f);
    }

    private void PlayPrologue()
    {
        Invoke("PlayPrologueMusic", 1f);
        ts_prologue.Release();
        IntroVideo.SetActive(true);
        IntroVideo.GetComponent<VideoPlayer>().Play();
    }

    private void PlayPrologueMusic()
    {
        IntroMusic.Play();
    }

    private void dialog()
    {
        gameBaseController.DialogIndex = gameBaseController.DialogIndex + 1;
        gameBaseController.ShowDialogRow();
    }

    private void showBox()
    {
        dialogBox.SetActive(true);
    }
    private void hideBox()
    {
        dialogBox.SetActive(false);
    }
    private void End0()
    {
        IntroVideo.SetActive(false);
        gameBaseController.DialogProcessing = false;
        gameBaseController.AreaID = 1;
        gameBaseController.EventID = 0;
        tsMainScript.ProceedGame(gameBaseController.ChapterID, gameBaseController.AreaID, false);
    }

}
