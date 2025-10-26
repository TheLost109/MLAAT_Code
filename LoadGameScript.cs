using DG.Tweening;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScript : MonoBehaviour
{
    public SaveDataScripts saveDataScripts;

    public AudioSource cancelSFX;
    public AudioSource ketteiSFX;
    public AudioSource SavedSFX;
    public AudioSource sentaku_fukanou;

    private string SavePath;
    private int SelectedSlot;
    private int CurrentGame;

    public GameObject SaveGameTitle;
    public GameObject LoadGameDataNotify;

    public int Hided = 1;
    private bool InAlertScreen = false;
    private bool LoadState = true;

    public GameObject LoadGameScreen;
    public GameObject CloseLoadGame;

    public Sprite EmptySaveImg;
    public Sprite TSSaveImg;
    public Sprite MLISaveImg;
    public Sprite EoJSaveImg;

    public GameObject LoadGameAlert;
    public GameObject LoadGameAlertPanel;
    public GameObject LoadAlertQuestion;
    public GameObject LoadAlertYNBtns;
    public GameObject LoadAlertDoneBtn;
    public GameObject LoadAlertSlotImg;
    public GameObject LoadAlertSlotEmptyText;
    public GameObject LoadAlertSlotChapterID;
    public GameObject LoadAlertSlotChapterName;
    public GameObject LoadAlertSlotProgText;
    public GameObject LoadAlertSlotDateText;
    public GameObject LoadSuccess;

    public GameObject SaveSlot0Img;
    public GameObject SaveSlot1Img;
    public GameObject SaveSlot2Img;
    public GameObject SaveSlot3Img;
    public GameObject SaveSlot4Img;
    public GameObject SaveSlot5Img;
    public GameObject SaveSlot6Img;
    public GameObject SaveSlot7Img;
    public GameObject SaveSlot8Img;
    public GameObject SaveSlot9Img;

    public GameObject SaveSlot0EmptyText;
    public GameObject SaveSlot1EmptyText;
    public GameObject SaveSlot2EmptyText;
    public GameObject SaveSlot3EmptyText;
    public GameObject SaveSlot4EmptyText;
    public GameObject SaveSlot5EmptyText;
    public GameObject SaveSlot6EmptyText;
    public GameObject SaveSlot7EmptyText;
    public GameObject SaveSlot8EmptyText;
    public GameObject SaveSlot9EmptyText;

    public GameObject SaveSlot0ChapterID;
    public GameObject SaveSlot1ChapterID;
    public GameObject SaveSlot2ChapterID;
    public GameObject SaveSlot3ChapterID;
    public GameObject SaveSlot4ChapterID;
    public GameObject SaveSlot5ChapterID;
    public GameObject SaveSlot6ChapterID;
    public GameObject SaveSlot7ChapterID;
    public GameObject SaveSlot8ChapterID;
    public GameObject SaveSlot9ChapterID;

    public GameObject SaveSlot0ChapterName;
    public GameObject SaveSlot1ChapterName;
    public GameObject SaveSlot2ChapterName;
    public GameObject SaveSlot3ChapterName;
    public GameObject SaveSlot4ChapterName;
    public GameObject SaveSlot5ChapterName;
    public GameObject SaveSlot6ChapterName;
    public GameObject SaveSlot7ChapterName;
    public GameObject SaveSlot8ChapterName;
    public GameObject SaveSlot9ChapterName;

    public GameObject SaveSlot0ProgText;
    public GameObject SaveSlot1ProgText;
    public GameObject SaveSlot2ProgText;
    public GameObject SaveSlot3ProgText;
    public GameObject SaveSlot4ProgText;
    public GameObject SaveSlot5ProgText;
    public GameObject SaveSlot6ProgText;
    public GameObject SaveSlot7ProgText;
    public GameObject SaveSlot8ProgText;
    public GameObject SaveSlot9ProgText;

    public GameObject SaveSlot0DateText;
    public GameObject SaveSlot1DateText;
    public GameObject SaveSlot2DateText;
    public GameObject SaveSlot3DateText;
    public GameObject SaveSlot4DateText;
    public GameObject SaveSlot5DateText;
    public GameObject SaveSlot6DateText;
    public GameObject SaveSlot7DateText;
    public GameObject SaveSlot8DateText;
    public GameObject SaveSlot9DateText;

    private void Start()
    {
        LoadGameAlert.GetComponent<Image>().DOFade(0, 0);
        LoadSuccess.GetComponent<Graphic>().DOFade(0, 0);
        SavePath = Application.persistentDataPath + "/Save/";
    }

    private void Update()
    {
        if (!InAlertScreen)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                Hide();
            }
        }
        if(CurrentGame == 0)
        {
            SaveGameTitle.GetComponent<TMP_Text>().text = "逆转风暴";
        }
        else if (CurrentGame == 1)
        {
            SaveGameTitle.GetComponent<TMP_Text>().text = "小马调查员";
        }
        if (CurrentGame == 2)
        {
            SaveGameTitle.GetComponent<TMP_Text>().text = "正义之元";
        }

        if (LoadState)
        {
            LoadGameDataNotify.GetComponent<TMP_Text>().text = "请选择要读取的存档。";
        }
        else if (!LoadState)
        {
            LoadGameDataNotify.GetComponent<TMP_Text>().text = "请选择要保存的存档。";
        }
    }
    // 显示面板
    public void OpenLoadGame()
    {
        CurrentGame = SettingsScript.Instance.CurrentGame;
        SettingsScript.Instance.Halt = true;
        LoadState = true;
        RefreshSaveInfo(CurrentGame);
        LoadGameScreen.GetComponent<CanvasGroup>().DOKill();
        LoadGameScreen.SetActive(true);
        LoadGameScreen.GetComponent<CanvasGroup>().DOFade(1, .35f);
        LoadGameScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Hided = 0;
    }
    public void OpenSaveGame()
    {
        CurrentGame = SettingsScript.Instance.CurrentGame;
        SettingsScript.Instance.Halt = true;
        LoadState = false;
        RefreshSaveInfo(CurrentGame);
        LoadGameScreen.GetComponent<CanvasGroup>().DOKill();
        LoadGameScreen.SetActive(true);
        LoadGameScreen.GetComponent<CanvasGroup>().DOFade(1, .35f);
        LoadGameScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Hided = 0;
    }
    // 隐藏面板
    public void Hide()
    {
        if (Hided == 0)
        {
            // 防止与其他返回操作同时进行
            Invoke("DelayHide", .01f);
            cancelSFX.Play();
            LoadGameScreen.GetComponent<CanvasGroup>().DOKill();
            LoadGameScreen.GetComponent<CanvasGroup>().DOFade(0, 0);
            LoadGameScreen.SetActive(false);
        }
    }
    public void DelayHide()
    {
        Hided = 1;
        SettingsScript.Instance.Halt = false;
    }

    public void RefreshSaveInfo(int GameID)
    {
        string GameName;
        if (GameID == 0)
        {
            GameName = "TS";
        }
        else if (GameID == 1)
        {
            GameName = "MLI";
        }
        else if (GameID == 2)
        {
            GameName = "EoJ";
        }
        else
        {
            GameName = "TS";
        }
        for (int i = 0; i < 10; i++)
        {
            if (File.Exists(SavePath + "Save_" + GameName + "_" + i.ToString()))
            {
                //反系列化的过程
                //创建一个二进制格式化程序
                BinaryFormatter bf = new BinaryFormatter();
                //打开一个文件流
                FileStream fs = File.Open(SavePath + "Save_" + GameName + "_" + i.ToString(), FileMode.Open);
                //调用格式化程序的反序列化方法，将文件流转换为一个SystemData对象
                SaveDataScripts.SaveData saveData = (SaveDataScripts.SaveData)bf.Deserialize(fs);
                if (i == 0)
                {
                    SaveSlot0EmptyText.SetActive(false);
                    SaveSlot0ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot0DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot0Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot0ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot0ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot0ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 1)
                {
                    SaveSlot1EmptyText.SetActive(false);
                    SaveSlot1ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot1DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot1Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot1ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot1ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot1ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 2)
                {
                    SaveSlot2EmptyText.SetActive(false);
                    SaveSlot2ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot2DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot2Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot2ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot2ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot2ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 3)
                {
                    SaveSlot3EmptyText.SetActive(false);
                    SaveSlot3ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot3DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot3Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot3ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot3ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot3ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 4)
                {
                    SaveSlot4EmptyText.SetActive(false);
                    SaveSlot4ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot4DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot4Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot4ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot4ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot4ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 5)
                {
                    SaveSlot5EmptyText.SetActive(false);
                    SaveSlot5ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot5DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot5Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot5ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot5ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot5ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 6)
                {
                    SaveSlot6EmptyText.SetActive(false);
                    SaveSlot6ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot6DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot6Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot6ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot6ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot6ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 7)
                {
                    SaveSlot7EmptyText.SetActive(false);
                    SaveSlot7ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot7DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot7Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot7ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot7ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot7ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 8)
                {
                    SaveSlot8EmptyText.SetActive(false);
                    SaveSlot8ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot8DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot8Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot8ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot8ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot8ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                else if (i == 9)
                {
                    SaveSlot9EmptyText.SetActive(false);
                    SaveSlot9ChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
                    SaveSlot9DateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    if (GameName == "TS")
                    {
                        SaveSlot9Img.GetComponent<Image>().sprite = TSSaveImg;
                        SaveSlot9ChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                        if (saveData.ChapterID == 0)
                        {
                            SaveSlot9ProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                        }
                        else
                        {
                            SaveSlot9ProgText.GetComponent<TMP_Text>().text = "进度有误";
                        }
                    }
                }
                fs.Close();
            }
            else
            {
                if (i == 0)
                {
                    SaveSlot0EmptyText.SetActive(true);
                    SaveSlot0Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot0ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot0ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot0ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot0DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 1)
                {
                    SaveSlot1EmptyText.SetActive(true);
                    SaveSlot1Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot1ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot1ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot1ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot1DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 2)
                {
                    SaveSlot2EmptyText.SetActive(true);
                    SaveSlot2Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot2ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot2ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot2ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot2DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 3)
                {
                    SaveSlot3EmptyText.SetActive(true);
                    SaveSlot3Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot3ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot3ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot3ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot3DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 4)
                {
                    SaveSlot4EmptyText.SetActive(true);
                    SaveSlot4Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot4ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot4ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot4ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot4DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 5)
                {
                    SaveSlot5EmptyText.SetActive(true);
                    SaveSlot5Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot5ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot5ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot5ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot5DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 6)
                {
                    SaveSlot6EmptyText.SetActive(true);
                    SaveSlot6Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot6ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot6ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot6ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot6DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 7)
                {
                    SaveSlot7EmptyText.SetActive(true);
                    SaveSlot7Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot7ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot7ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot7ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot7DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 8)
                {
                    SaveSlot8EmptyText.SetActive(true);
                    SaveSlot8Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot8ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot8ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot8ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot8DateText.GetComponent<TMP_Text>().text = "";
                }
                else if (i == 9)
                {
                    SaveSlot9EmptyText.SetActive(true);
                    SaveSlot9Img.GetComponent<Image>().sprite = EmptySaveImg;
                    SaveSlot9ChapterID.GetComponent<TMP_Text>().text = "";
                    SaveSlot9ChapterName.GetComponent<TMP_Text>().text = "";
                    SaveSlot9ProgText.GetComponent<TMP_Text>().text = "";
                    SaveSlot9DateText.GetComponent<TMP_Text>().text = "";
                }
            }
        }
    }
    public void SelectSave(int SlotId)
    {
        string GameName;
        SelectedSlot = SlotId;
        if (CurrentGame == 0)
        {
            GameName = "TS";
        }
        else if (CurrentGame == 1)
        {
            GameName = "MLI";
        }
        else if (CurrentGame == 2)
        {
            GameName = "EoJ";
        }
        else
        {
            GameName = "TS";
        }
        if (File.Exists(SavePath + "Save_" + GameName + "_" + SlotId.ToString()))
        {
            LoadAlertSlotEmptyText.SetActive(false);
            //反系列化的过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fs = File.Open(SavePath + "Save_" + GameName + "_" + SlotId.ToString(), FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个SystemData对象
            SaveDataScripts.SaveData saveData = (SaveDataScripts.SaveData)bf.Deserialize(fs);
            LoadAlertSlotChapterID.GetComponent<TMP_Text>().text = "第" + ( saveData.ChapterID + 1 ) + "章";
            LoadAlertSlotDateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
            if (GameName == "TS")
            {
                LoadAlertSlotImg.GetComponent<Image>().sprite = TSSaveImg;
                LoadAlertSlotChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
                if(saveData.ChapterID == 0)
                {
                    LoadAlertSlotProgText.GetComponent<TMP_Text>().text = "第1天 调查";
                }
                else
                {
                    LoadAlertSlotProgText.GetComponent<TMP_Text>().text = "进度有误";
                }
            }
            fs.Close();
            ShowLoadGameAlert();
            ketteiSFX.Play();
}
        else
        {
            if(!LoadState)
            {
                ketteiSFX.Play();
                LoadAlertSlotImg.GetComponent<Image>().sprite = EmptySaveImg;
                LoadAlertSlotEmptyText.SetActive(true);
                LoadAlertSlotChapterID.SetActive(false);
                LoadAlertSlotChapterName.SetActive(false);
                LoadAlertSlotProgText.SetActive(false);
                LoadAlertSlotDateText.SetActive(false);
                ShowLoadGameAlert();
            }
            else
            {
                sentaku_fukanou.Play();
            }
        }
    }
    private void ShowLoadGameAlert()
    {
        InAlertScreen = true;
        LoadGameAlert.SetActive(true);
        LoadGameAlert.GetComponent<Image>().DOFade(.99f, .35f);
        Invoke("ShowLoadGameAlertPanel", .35f);
    }

    private void ShowLoadGameAlertPanel()
    {
        if (LoadState)
        {
            LoadAlertQuestion.GetComponent<TMP_Text>().text = "确定要读取以下存档吗？";
        }
        else
        {
            LoadAlertQuestion.GetComponent<TMP_Text>().text = "确定要保存至以下存档吗？";
        }
        LoadGameAlertPanel.SetActive(true);
        LoadAlertYNBtns.SetActive(true);
        LoadAlertDoneBtn.SetActive(false);
    }
    public void LoadGameConfirm()
    {
        if (LoadState)
        {
            ketteiSFX.Play();
            SettingsScript.Instance.Halt = false;
            LoadSuccess.SetActive(true);
            LoadSuccess.GetComponent<Graphic>().DOFade(1, .5f);
            if (CurrentGame == 0)
            {
                SettingsScript.Instance.LoadFileName = "Save_TS_" + SelectedSlot;
                Invoke("LoadTSScene", 3f);
            }
            //else if (CurrentGame == 1)
            //{
            //    SettingsScript.Instance.LoadFileName = "Save_MLI_" + SelectedSlot;
            //    Invoke("LoadMLIScene", 3f);
            //}
            //else if (CurrentGame == 2)
            //{
            //    SettingsScript.Instance.LoadFileName = "Save_MLI_" + SelectedSlot;
            //    Invoke("LoadEoJScene", 3f);
            //}
        }
        else
        {
            SavedSFX.Play();
            LoadAlertQuestion.GetComponent<TMP_Text>().text = "保存中...";
            LoadAlertYNBtns.SetActive(false);
            if (CurrentGame == 0)
            {
                saveDataScripts.SaveBySerialization("Save_TS_" + SelectedSlot);
                Invoke("SaveGameDone", 2f);
            }
            //else if (CurrentGame == 1)
            //{
            //
            //}
            //else if (CurrentGame == 2)
            //{
            //
            //}
        }
    }
    public void SaveGameDone()
    {
        LoadAlertSlotEmptyText.SetActive(false);
        LoadAlertQuestion.GetComponent<TMP_Text>().text = "保存完毕";
        LoadAlertDoneBtn.SetActive(true);
        //反系列化的过程
        //创建一个二进制格式化程序
        BinaryFormatter bf = new BinaryFormatter();
        //打开一个文件流
        FileStream fs = File.Open(SavePath + "Save_TS_" + SelectedSlot.ToString(), FileMode.Open);
        //调用格式化程序的反序列化方法，将文件流转换为一个SaveData对象
        SaveDataScripts.SaveData saveData = (SaveDataScripts.SaveData)bf.Deserialize(fs);
        LoadAlertSlotChapterID.GetComponent<TMP_Text>().text = "第" + (saveData.ChapterID + 1) + "章";
        LoadAlertSlotDateText.GetComponent<TMP_Text>().text = saveData.dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        LoadAlertSlotImg.GetComponent<Image>().sprite = TSSaveImg;
        LoadAlertSlotChapterName.GetComponent<TMP_Text>().text = "逆转风暴";
        if (saveData.ChapterID == 0)
        {
            LoadAlertSlotProgText.GetComponent<TMP_Text>().text = "第1天 调查";
        }
        else
        {
            LoadAlertSlotProgText.GetComponent<TMP_Text>().text = "进度有误";
        }
        fs.Close();
        LoadAlertSlotChapterID.SetActive(true);
        LoadAlertSlotChapterName.SetActive(true);
        LoadAlertSlotProgText.SetActive(true);
        LoadAlertSlotDateText.SetActive(true);
        RefreshSaveInfo(CurrentGame);
    }
    public void LoadGameCancel()
    {
        InAlertScreen = false;
        LoadGameAlertPanel.SetActive(false);
        LoadGameAlert.GetComponent<Image>().DOFade(0, 0);
        LoadGameAlert.SetActive(false);
    }
    public void LoadTSScene()
    {
        SceneManager.LoadScene("TSGame");
    }
}