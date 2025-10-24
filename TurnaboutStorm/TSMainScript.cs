using UnityEngine;

public class TSMainScript : MonoBehaviour
{
    // ÓÎÏ·»ù´¡½Å±¾
    public GameBaseController gameBaseController;
    public SaveDataScripts saveDataScripts;
    public TSScriptC0A0 tsScriptC0A0;
    public TSScriptC0A1 tsScriptC0A1;
    public TSScriptC0A2 tsScriptC0A2;
    public string CurrentScript = "";

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (SettingsScript.Instance.LoadFileName == "")
        {
            ProceedGame(gameBaseController.ChapterID, gameBaseController.AreaID, false);
        }
        else
        {
            saveDataScripts.LoadBySerialization(SettingsScript.Instance.LoadFileName);
            SettingsScript.Instance.LoadFileName = "";
            SystemDataScripts.Instance.SaveBySerialization();
            ProceedGame(gameBaseController.ChapterID, gameBaseController.AreaID, true);
        }
    }

    // Update is called once per frame
    private void Update()
    {

        if (gameBaseController.Proceed)
        {
            ProceedGame(gameBaseController.ChapterID, gameBaseController.AreaID, false);
            gameBaseController.Proceed = false;
        }
    }

    public void ProceedGame(int ChapterID, int AreaID, bool IsContinue)
    {
        if (ChapterID == 0)
        {
            if (AreaID == 0)
            {
                tsScriptC0A0.ProceedGame();
            }
            if (AreaID == 1)
            {
                tsScriptC0A1.ProceedGame(gameBaseController.EventID, IsContinue);
            }
            if (AreaID == 2)
            {
                tsScriptC0A2.ProceedGame(gameBaseController.EventID, IsContinue);
            }
        }
    }
}
