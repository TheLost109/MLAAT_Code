using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

public class SaveDataScripts : MonoBehaviour
{
    public GameBaseController gameBaseController;

    // 单例模式
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
        // 检查文件夹是否存在
        if (!Directory.Exists(SavePath))
        {
            // 创建文件夹
            Directory.CreateDirectory(SavePath);
            Debug.Log("新文件夹创建成功: " + SavePath);
        }
        else
        {
            Debug.Log("文件夹已存在");
        }
        SaveData saveData = CreateSaveData();
        //获取当前的游戏数据存在Save对象里
        BinaryFormatter bf = new BinaryFormatter();
        //创建一个二进制形式
        FileStream fs = File.Create(SavePath + "/" + FileName);
        //这里指使用持久路径创建一个文件流并将其保存在systemdata里（具体在哪就不打了，反正创建了）
        //由于持久路径在Windows系统是隐藏的，所以无法找到systemdata本身
        //如果想看到，可以改成dataPath(就像下文json的代码里一样)
        //文件后缀可以随便改，甚至是自定义的（比如我这里用了systemdata）
        bf.Serialize(fs, saveData);
        //将Save对象转化为字节
        fs.Close();
        //把文件流关了
    }
    public void LoadBySerialization(string FileName)
    {
        string SavePath = Application.persistentDataPath + "/Save";
        if (File.Exists(SavePath + "/" + FileName))
        //判断文件是否创建
        {
            //反系列化的过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fs = File.Open(SavePath + "/" + FileName, FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个SystemData对象
            SaveData saveData = (SaveData)bf.Deserialize(fs);
            gameBaseController.ChapterID = saveData.ChapterID;
            gameBaseController.AreaID = saveData.AreaID;
            gameBaseController.EventID = saveData.EventID;
            gameBaseController.Health = saveData.Health;
            gameBaseController.RecordsEvidence = saveData.RecordsEvidence;
            gameBaseController.RecordsProfile = saveData.RecordsProfile;
            //关闭文件流
            fs.Close();
            //DataCarrier.Instance.LoadIntoGame = true;
            //if(FileName == "Save_TS_0")
            //{
            //    Invoke("GoToTSGame", 3f);
            //}
        }
        else
        {
            Debug.LogError("读档出现错误。");
        }
    }

}
