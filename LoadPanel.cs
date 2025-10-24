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
        //�ж��ļ��Ƿ񴴽�
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
            QuestionText.text = "ȷ��Ҫ��ȡ���´浵��";
            //��ϵ�л��Ĺ���
            //����һ�������Ƹ�ʽ������
            BinaryFormatter bf = new BinaryFormatter();
            //��һ���ļ���
            FileStream fs = File.Open(SavePath + "/" + FileName, FileMode.Open);
            //���ø�ʽ������ķ����л����������ļ���ת��Ϊһ��SystemData����
            SaveDataScripts.SaveData saveData = (SaveDataScripts.SaveData)bf.Deserialize(fs);
            if (saveData.ChapterID == 0)
            {
                ProgText.text = "��1�죺����";
            }
            else
            {
                ProgText.text = "��������";
            }
            DateText.text = saveData.dateTime.ToString("yyyy��MM��dd�� HH:mm");
            //�ر��ļ���
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
            QuestionText.text = "δ��⵽�浵��";
            LoadCan.SetActive(false);
            LoadCant.SetActive(true);
            Debug.Log("δ��⵽�浵");
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