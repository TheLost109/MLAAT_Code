using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SystemDataScripts : MonoBehaviour
{
    // ����ģʽ
    public static SystemDataScripts Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        LoadBySerialization();
    }

    [Serializable]
    public class SystemData
    {
        public bool FirstRun;
        public float BGMVol;
        public float SEVol;
        public string Language;
        public string VoiceLang;
        public int MSAA;
        public bool VSyncEnabled;
        public int MaxFPS;
        public string LoadFileName;
    }

    public SystemData CreateSysData()
    {
        SystemData systemData = new SystemData();
        systemData.FirstRun = SettingsScript.Instance.FirstRun;
        systemData.BGMVol = SettingsScript.Instance.BGMVol;
        systemData.SEVol = SettingsScript.Instance.SEVol;
        systemData.Language = SettingsScript.Instance.Language;
        systemData.VoiceLang = SettingsScript.Instance.VoiceLang;
        systemData.MSAA = SettingsScript.Instance.MSAA;
        systemData.VSyncEnabled = SettingsScript.Instance.VSyncEnabled;
        systemData.MaxFPS = SettingsScript.Instance.MaxFPS;
        systemData.LoadFileName = SettingsScript.Instance.LoadFileName;
        return systemData;
    }

    public void SaveBySerialization()
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
        SystemData systemData = CreateSysData();
        //��ȡ��ǰ����Ϸ���ݴ���Save������
        BinaryFormatter bf = new BinaryFormatter();
        //����һ����������ʽ
        FileStream fs = File.Create(SavePath + "/systemdata");
        //����ָʹ�ó־�·������һ���ļ��������䱣����systemdata��������ľͲ����ˣ����������ˣ�
        //���ڳ־�·����Windowsϵͳ�����صģ������޷��ҵ�systemdata����
        //����뿴�������Ըĳ�dataPath(��������json�Ĵ�����һ��)
        //�ļ���׺�������ģ��������Զ���ģ���������������systemdata��
        bf.Serialize(fs, systemData);
        //��Save����ת��Ϊ�ֽ�
        fs.Close();
        //���ļ�������
    }
    public void LoadBySerialization()
    {
        string SavePath = Application.persistentDataPath + "/Save";
        if (File.Exists(SavePath + "/systemdata"))
        //�ж��ļ��Ƿ񴴽�
        {
            //��ϵ�л��Ĺ���
            //����һ�������Ƹ�ʽ������
            BinaryFormatter bf = new BinaryFormatter();
            //��һ���ļ���
            FileStream fs = File.Open(SavePath + "/systemdata", FileMode.Open);
            //���ø�ʽ������ķ����л����������ļ���ת��Ϊһ��SystemData����
            SystemData systemData = (SystemData)bf.Deserialize(fs);
            SettingsScript.Instance.FirstRun = systemData.FirstRun;
            SettingsScript.Instance.BGMVol = systemData.BGMVol;
            SettingsScript.Instance.SEVol = systemData.SEVol;
            SettingsScript.Instance.Language = systemData.Language;
            SettingsScript.Instance.VoiceLang = systemData.VoiceLang;
            SettingsScript.Instance.MSAA = systemData.MSAA;
            SettingsScript.Instance.VSyncEnabled = systemData.VSyncEnabled;
            SettingsScript.Instance.MaxFPS = systemData.MaxFPS;
            SettingsScript.Instance.LoadFileName = systemData.LoadFileName;
            //�ر��ļ���
            fs.Close();
        }
        else
        {
            Debug.LogError("δ��⵽systemdata�����ڴ�����");
            SaveBySerialization();
        }
    }

}
