using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;

public class SettingsScript : MonoBehaviour
{
    // �Ƿ��״�������Ϸ
    public bool FirstRun = true;

    // �������� ���
    public string Language = "Chinese";
    public string VoiceLang = "Japanese";

    // BGM & SE ����
    public AudioMixer AudioMixer;
    public float BGMVol = 5;
    public float SEVol = 5;

    // PC�趨
    public UniversalRenderPipelineAsset URPAsset;
    public int MSAA = 0;
    public bool VSyncEnabled = true;
    public int MaxFPS = 60;

    // ������Ҫ��ȡ�Ĵ浵����
    public string LoadFileName = "";

    // ����ģʽ
    public static SettingsScript Instance;
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
        SetBGMVolume(BGMVol);
        SetSEVolume(SEVol);
        SetMSAA(MSAA);
        SetVSync(VSyncEnabled);
        SetMaxFPS(MaxFPS);
    }

    private void Update()
    {

    }

    ///<summary>
    ///    https://www.cnblogs.com/alanshreck/p/14746347.html
    ///</summary>
    // ����BGM����
    public void SetBGMVolume(float v)
    {
        BGMVol = v;
        if (v == 5)
        {
            AudioMixer.SetFloat("BGM", 0);
        }
        else if (v == 4)
        {
            AudioMixer.SetFloat("BGM", -8);
        }
        else if (v == 3)
        {
            AudioMixer.SetFloat("BGM", -16);
        }
        else if (v == 2)
        {
            AudioMixer.SetFloat("BGM", -24);
        }
        else if (v == 1)
        {
            AudioMixer.SetFloat("BGM", -32);
        }
        else if (v == 0)
        {
            AudioMixer.SetFloat("BGM", -80);
        }
    }

    // ����SE����
    public void SetSEVolume(float v)
    {
        SEVol = v;
        if (v == 5)
        {
            AudioMixer.SetFloat("SE", 0);
        }
        else if (v == 4)
        {
            AudioMixer.SetFloat("SE", -8);
        }
        else if (v == 3)
        {
            AudioMixer.SetFloat("SE", -16);
        }
        else if (v == 2)
        {
            AudioMixer.SetFloat("SE", -24);
        }
        else if (v == 1)
        {
            AudioMixer.SetFloat("SE", -32);
        }
        else if (v == 0)
        {
            AudioMixer.SetFloat("SE", -80);
        }
    }
    // ����MSAA
    public void SetMSAA(int MSAA)
    {
        URPAsset.msaaSampleCount = MSAA;
    }
    // ���ô�ֱͬ��
    public void SetVSync(bool VSyncEnabled)
    {
        if(VSyncEnabled){
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
    // ����֡��
    public void SetMaxFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
