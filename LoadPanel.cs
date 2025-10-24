using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    public TMP_Text DateText;
    public TMP_Text ProgText;
    public TMP_Text QuestionText;
    public GameObject LoadCan;
    public GameObject LoadCant;
    public GameObject LoadSuccess;

    public AudioSource kettei;
    public AudioSource kettei_TS;
    public AudioSource NoSaveSFX;
    public AudioSource NoSaveSFX_TS;

    public void LoadSaveInfo(string FileName)
    {
        string SavePath = Application.persistentDataPath + "/Save";
        //判断文件是否创建
        if (File.Exists(SavePath + "/" + FileName))
        {
            if (FileName == "Save_TS_0")
            {
                kettei_TS.Play();
            }
            else
            {
                kettei.Play();
            }
            LoadCan.SetActive(true);
            LoadCant.SetActive(false);
            QuestionText.text = "确定要读取以下存档吗？";
            //反系列化的过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fs = File.Open(SavePath + "/" + FileName, FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个SystemData对象
            SaveDataScripts.SaveData saveData = (SaveDataScripts.SaveData)bf.Deserialize(fs);
            if (saveData.ChapterID == 0)
            {
                ProgText.text = "第1天：调查";
            }
            else
            {
                ProgText.text = "进度有误";
            }
            DateText.text = saveData.dateTime.ToString("yyyy年MM月dd日 HH:mm");
            //关闭文件流
            fs.Close();
        }
        else
        {
            if (FileName == "Save_TS_0")
            {
                NoSaveSFX_TS.Play();
            }
            else
            {
                NoSaveSFX.Play();
            }
            QuestionText.text = "未检测到存档。";
            LoadCan.SetActive(false);
            LoadCant.SetActive(true);
            Debug.Log("未检测到存档");
        }
    }

    public void TSLoad()
    {
        SettingsScript.Instance.LoadFileName = "Save_TS_0";
        SystemDataScripts.Instance.SaveBySerialization();
        LoadSuccess.SetActive(true);
        LoadSuccess.GetComponent<Graphic>().CrossFadeAlpha(1f, .25f, false);
        Invoke("LoadTSScene", 3f);
    }

    public void LoadTSScene()
    {
        SceneManager.LoadScene("TSGame");
    }

}