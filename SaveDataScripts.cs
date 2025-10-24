using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

public class SaveDataScripts : MonoBehaviour
{
    public GameBaseController gameBaseController;

    // ����ģʽ
    public static SaveDataScripts Instance;
    private void Awake()
    {
        //if (Instance != null && Instance != this)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    [Serializable]
    public class SaveData
    {
        public DateTime dateTime;
        public int ChapterID;
        public int AreaID;
        public int EventID;
        public int Health;
        public List<Records> RecordsEvidence = new List<Records>();
        public List<Records> RecordsProfile = new List<Records>();
    }

    public SaveData CreateSaveData()
    {
        SaveData saveData = new SaveData();
        saveData.dateTime = DateTime.Now;
        saveData.ChapterID = gameBaseController.ChapterID;
        saveData.AreaID = gameBaseController.AreaID;
        saveData.EventID = gameBaseController.EventID;
        saveData.Health = gameBaseController.Health;
        saveData.RecordsEvidence = gameBaseController.RecordsEvidence;
        saveData.RecordsProfile = gameBaseController.RecordsProfile;
        return saveData;
    }

    public void SaveBySerialization(string FileName)
    {
        string SavePath = Application.persistentDataPath + "/Save";
        // ����ļ����Ƿ����
        if (!Directory.Exists(SavePath))
        {
            // �����ļ���
            Directory.CreateDirectory(SavePath);
            Debug.Log("���ļ��д����ɹ�: " + SavePath);
        }
        else
        {
            Debug.Log("�ļ����Ѵ���");
        }
        SaveData saveData = CreateSaveData();
        //��ȡ��ǰ����Ϸ���ݴ���Save������
        BinaryFormatter bf = new BinaryFormatter();
        //����һ����������ʽ
        FileStream fs = File.Create(SavePath + "/" + FileName);
        //����ָʹ�ó־�·������һ���ļ��������䱣����systemdata��������ľͲ����ˣ����������ˣ�
        //���ڳ־�·����Windowsϵͳ�����صģ������޷��ҵ�systemdata����
        //����뿴�������Ըĳ�dataPath(��������json�Ĵ�����һ��)
        //�ļ���׺�������ģ��������Զ���ģ���������������systemdata��
        bf.Serialize(fs, saveData);
        //��Save����ת��Ϊ�ֽ�
        fs.Close();
        //���ļ�������
    }
    public void LoadBySerialization(string FileName)
    {
        string SavePath = Application.persistentDataPath + "/Save";
        if (File.Exists(SavePath + "/" + FileName))
        //�ж��ļ��Ƿ񴴽�
        {
            //��ϵ�л��Ĺ���
            //����һ�������Ƹ�ʽ������
            BinaryFormatter bf = new BinaryFormatter();
            //��һ���ļ���
            FileStream fs = File.Open(SavePath + "/" + FileName, FileMode.Open);
            //���ø�ʽ������ķ����л����������ļ���ת��Ϊһ��SystemData����
            SaveData saveData = (SaveData)bf.Deserialize(fs);
            gameBaseController.ChapterID = saveData.ChapterID;
            gameBaseController.AreaID = saveData.AreaID;
            gameBaseController.EventID = saveData.EventID;
            gameBaseController.Health = saveData.Health;
            gameBaseController.RecordsEvidence = saveData.RecordsEvidence;
            gameBaseController.RecordsProfile = saveData.RecordsProfile;
            //�ر��ļ���
            fs.Close();
            //DataCarrier.Instance.LoadIntoGame = true;
            //if(FileName == "Save_TS_0")
            //{
            //    Invoke("GoToTSGame", 3f);
            //}
        }
        else
        {
            Debug.LogError("�������ִ���");
        }
    }

}
