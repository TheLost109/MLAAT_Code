using UnityEngine;
using UnityEngine.Video;

public class TSScriptC0A0 : MonoBehaviour
{
    // ��Ϸ�����ű�
    public GameBaseController gameBaseController;
    // ��ת�籩�����ű�
    public TSMainScript tsMainScript;
    // ��ͥ��¼�ű�
    public CourtRecordsSystem courtRecordsSystem;
    // �Ի��ļ�
    public TextAsset DialogFile;
    // �Ի���
    public GameObject dialogBox;
    // �Ի��������Ʊ�ǩ
    public GameObject NameTag;
    // �Ի��ı�
    public GameObject SpeechText;
    // Area 0 ��Ļ
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
            // ��ȡ TextAsset
            tsMainScript.CurrentScript = "TSScriptC0A0";
            gameBaseController.SendMessage("ReadText", DialogFile);
            print(gameBaseController.EventID);
        }
        gameBaseController.DialogProcessing = true;
        Debug.Log("�Ѷ�ȡ�Ի��ı�0");
        // ����
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
