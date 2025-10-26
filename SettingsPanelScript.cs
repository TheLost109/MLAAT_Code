using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanelScript : MonoBehaviour
{
    // �˳���Ч
    public AudioSource ExitSFX;

    public CanvasGroup SettingsScreen;
    public GameObject CloseSettings;
    public int Hided = 1;

    // ��Ƶ���� ���
    public AudioMixer AudioMixer;
    public Slider BGMSlider;
    public Slider SESlider;


    // �������� ���
    public GameObject VoiceLangToggleText;
    public GameObject ObjBubble;
    public GameObject ObjBubbleEN;
    public GameObject ObjBubbleCN;
    public AudioSource ObjVoice;
    public AudioSource ObjVoiceEN;
    public AudioSource ObjVoiceCN;

    // �Ҳ���� 
    public int CurrentSets = 0;
    public GameObject DataSLPanel;
    public GameObject AudioSets;
    public GameObject LanguageSets;
    public GameObject PCSets;

    // PC���� ���
    public GameObject FullscreenToggleText;
    public GameObject ResolutionToggleText;
    public GameObject MSAAToggleText;
    public GameObject VSyncToggleText;
    public GameObject MaxFPSSettings;
    public GameObject MaxFPSToggleText;

    // �������� ���
    public GameObject LanguageToggleText;


    // ������ ���
    public GameObject DataSLBtn;
    public GameObject DataSLBtnSel;
    public GameObject AudioSetsBtn;
    public GameObject AudioSetsBtnSel;
    public GameObject LangSetsBtn;
    public GameObject LangSetsBtnSel;
    public GameObject PCConfigBtn;
    public GameObject PCConfigBtnSel;

    private void Start()
    {

    }
    private void Update()
    {
        if (SettingsScript.Instance.Halt)
        {
            CloseSettings.SetActive(false);
        }
        else
        {
            CloseSettings.SetActive(true);
        }
        // �˳�����
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(1))
        {
            if (!SettingsScript.Instance.Halt)
            {
                Hide();
            }
        }
        // ���ȫ������״̬������ʾ��Ӧ����
        if (Screen.fullScreen)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                FullscreenToggleText.GetComponent<TMP_Text>().text = ("��");
            }
            else if(SettingsScript.Instance.Language == "English")
            {
                FullscreenToggleText.GetComponent<TMP_Text>().text = ("ON");
            }
        }
        else
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                FullscreenToggleText.GetComponent<TMP_Text>().text = ("��");
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                FullscreenToggleText.GetComponent<TMP_Text>().text = ("OFF");
            }
        }
        // ��⵱ǰ�ֱ��ʣ�����ʾ��Ӧ����
        ResolutionToggleText.GetComponent<TMP_Text>().text = (Screen.width + "x" + Screen.height);

        // ���ѡ�е����ã����ı��Ҳ����
        if (CurrentSets == 0)
        {
            ClearLeftBtnsSel();
            RightPanelReset();
            AudioSetsBtnSel.SetActive(true);
            AudioSets.SetActive(true);
        }
        else if (CurrentSets == 1)
        {
            ClearLeftBtnsSel();
            RightPanelReset();
            LangSetsBtnSel.SetActive(true);
            LanguageSets.SetActive(true);
        }
        else if (CurrentSets == 2)
        {
            ClearLeftBtnsSel();
            RightPanelReset();
            PCConfigBtnSel.SetActive(true);
            PCSets.SetActive(true);
        }
        else if (CurrentSets == 99)
        {
            ClearLeftBtnsSel();
            RightPanelReset();
            DataSLBtnSel.SetActive(true);
            DataSLPanel.SetActive(true);
        }
        else
        {
            CurrentSets = 0;
            ClearLeftBtnsSel();
            RightPanelReset();
        }

        // ��⵱ǰ��Ϸ����
        if (SettingsScript.Instance.Language == "Chinese")
        {
            LanguageToggleText.GetComponent<TMP_Text>().text = ("��������");
        }
        else if (SettingsScript.Instance.Language == "English")
        {
            LanguageToggleText.GetComponent<TMP_Text>().text = ("English");
        }
        else
        {
            SettingsScript.Instance.Language = "Chinese";
        }

        // ��⵱ǰ��������
        if (SettingsScript.Instance.VoiceLang == "Japanese")
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                VoiceLangToggleText.GetComponent<TMP_Text>().text = ("����");
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                VoiceLangToggleText.GetComponent<TMP_Text>().text = ("Japanese");
            }
        }
        else if (SettingsScript.Instance.VoiceLang == "English")
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                VoiceLangToggleText.GetComponent<TMP_Text>().text = ("Ӣ��");
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                VoiceLangToggleText.GetComponent<TMP_Text>().text = ("English");
            }
        }
        else if (SettingsScript.Instance.VoiceLang == "Chinese")
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                VoiceLangToggleText.GetComponent<TMP_Text>().text = ("����");
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                VoiceLangToggleText.GetComponent<TMP_Text>().text = ("Chinese");
            }
        }
        else
        {
            SettingsScript.Instance.VoiceLang = "Japanese";
        }
        // MSAA������ʾ
        if(SettingsScript.Instance.MSAA == 0)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                MSAAToggleText.GetComponent<TMP_Text>().text = "��";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                MSAAToggleText.GetComponent<TMP_Text>().text = "OFF";
            }
        }
        else
        {
            MSAAToggleText.GetComponent<TMP_Text>().text = SettingsScript.Instance.MSAA.ToString() + "x";
        }
        // ��ֱͬ��״̬��ʾ
        if (SettingsScript.Instance.VSyncEnabled)
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                VSyncToggleText.GetComponent<TMP_Text>().text = "��";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                VSyncToggleText.GetComponent<TMP_Text>().text = "ON";
            }
            MaxFPSSettings.SetActive(false);
        }
        else
        {
            if (SettingsScript.Instance.Language == "Chinese")
            {
                VSyncToggleText.GetComponent<TMP_Text>().text = "��";
            }
            else if (SettingsScript.Instance.Language == "English")
            {
                VSyncToggleText.GetComponent<TMP_Text>().text = "OFF";
            }
            MaxFPSSettings.SetActive(true);
        }
        // ���FPS��ʾ
        if (SettingsScript.Instance.MaxFPS != -1)
        {
            MaxFPSToggleText.GetComponent<TMP_Text>().text = SettingsScript.Instance.MaxFPS.ToString();
        }
        else
        {
            if(SettingsScript.Instance.Language == "Chinese")
            {
                MaxFPSToggleText.GetComponent<TMP_Text>().text = "������";
            }
            else if(SettingsScript.Instance.Language == "English")
            {
                MaxFPSToggleText.GetComponent<TMP_Text>().text = "No Limit";
            }
        }

    }

    // ���������尴ť״̬
    public void ClearLeftBtnsSel()
    {
        DataSLBtn.SetActive(true);
        DataSLBtnSel.SetActive(false);
        AudioSetsBtn.SetActive(true);
        AudioSetsBtnSel.SetActive(false);
        LangSetsBtn.SetActive(true);
        LangSetsBtnSel.SetActive(false);
        PCConfigBtn.SetActive(true);
        PCConfigBtnSel.SetActive(false);
    }

    // �������
    public void Hide()
    {
        if (Hided == 0)
        {
            // ��ֹ���������ز���ͬʱ����
            Invoke("DelayHide", .01f);
            ExitSFX.Play();
            SettingsScreen.DOKill();
            SettingsScreen.DOFade(0, 0);
            SettingsScreen.blocksRaycasts = false;
            SystemDataScripts.Instance.SaveBySerialization();
        }
    }

    public void DelayHide()
    {
        Hided = 1;
    }

    public void LanguageToggle()
    {
        if (SettingsScript.Instance.Language == "Chinese")
        {
            SettingsScript.Instance.Language = "English";
        }
        else if (SettingsScript.Instance.Language == "English")
        {
            SettingsScript.Instance.Language = "Chinese";
        }
        else
        {
            SettingsScript.Instance.Language = "Chinese";
        }
    }

    // ���ط�������
    public void ObjBubbleHide()
    {
        ObjBubble.SetActive(false);
        ObjBubbleEN.SetActive(false);
        ObjBubbleCN.SetActive(false);
    }

    // ��ʾ���
    public void OpenSettings()
    {
        BGMSlider.value = SettingsScript.Instance.BGMVol;
        SESlider.value = SettingsScript.Instance.SEVol;
        SettingsScreen.DOKill();
        SettingsScreen.DOFade(1, .35f);
        SettingsScreen.blocksRaycasts = true;
        Hided = 0;
    }

    // ���ӷֱ���
    public void ResBigger()
    {
        if (Screen.width < 1280)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else
            {
                Screen.SetResolution(1280, 720, false);
            }
        }
        if (Screen.width == 1280)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1366, 768, true);
            }
            else
            {
                Screen.SetResolution(1366, 768, false);
            }
        }
        else if (Screen.width == 1366)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1600, 900, true);
            }
            else
            {
                Screen.SetResolution(1600, 900, false);
            }
        }
        else if (Screen.width == 1600)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
        }
        else if (Screen.width >= 1920)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else
            {
                Screen.SetResolution(1280, 720, false);
            }
        }
    }

    // ��С�ֱ���
    public void ResSmaller()
    {
        if (Screen.width <= 1280)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
        }
        else if (Screen.width == 1366)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, true);
            }
            else
            {
                Screen.SetResolution(1280, 720, false);
            }
        }
        else if (Screen.width == 1600)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1366, 768, true);
            }
            else
            {
                Screen.SetResolution(1366, 768, false);
            }
        }
        else if (Screen.width == 1920)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1600, 900, true);
            }
            else
            {
                Screen.SetResolution(1600, 900, false);
            }
        }
        else if (Screen.width > 1920)
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1920, 1080, true);
            }
            else
            {
                Screen.SetResolution(1920, 1080, false);
            }
        }
    }

    public void RightPanelReset()
    {
        DataSLPanel.SetActive(false);
        AudioSets.SetActive(false);
        LanguageSets.SetActive(false);
        PCSets.SetActive(false);
    }

    // ����ѡ�
    public void SetLeftPanelChange(int num)
    {
        if (num == 0)
        {
            CurrentSets = 0;
        }
        else if (num == 1)
        {
            CurrentSets = 1;
        }
        else if (num == 2)
        {
            CurrentSets = 2;
        }
        else if (num == 99)
        {
            CurrentSets = 99;
        }
        else
        {
            CurrentSets = 0;
        }
    }

    // �л�ȫ��
    public void ToggleFullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void VoiceLangToggle(int direction)
    {
        if ((SettingsScript.Instance.VoiceLang == "Japanese" && direction == 1) || (SettingsScript.Instance.VoiceLang == "Chinese" && direction == 0))
        {
            SettingsScript.Instance.VoiceLang = "English";
            ObjBubbleEN.SetActive(true);
            ObjVoiceEN.Play();
            Invoke("ObjBubbleHide", 2f);
        }
        else if ((SettingsScript.Instance.VoiceLang == "English" && direction == 1) || (SettingsScript.Instance.VoiceLang == "Japanese" && direction == 0))
        {
            SettingsScript.Instance.VoiceLang = "Chinese";
            ObjBubbleCN.SetActive(true);
            ObjVoiceCN.Play();
            Invoke("ObjBubbleHide", 2f);
        }
        else if ((SettingsScript.Instance.VoiceLang == "Chinese" && direction == 1) || (SettingsScript.Instance.VoiceLang == "English" && direction == 0))
        {
            SettingsScript.Instance.VoiceLang = "Japanese";
            ObjBubble.SetActive(true);
            ObjVoice.Play();
            Invoke("ObjBubbleHide", 2f);
        }
    }

    ///<summary>
    ///    https://www.cnblogs.com/alanshreck/p/14746347.html
    ///</summary>
    // ����BGM����
    public void SetBGMVolume(float v)
    {
        SettingsScript.Instance.BGMVol = v;
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
        SettingsScript.Instance.SEVol = v;
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
    // MSAA ���ز��������
    public void SetMSAAValue(int direction)
    {
        if (direction == 0)
        {
            if (SettingsScript.Instance.MSAA == 0)
            {
                SettingsScript.Instance.MSAA = 8;
            }
            else if (SettingsScript.Instance.MSAA == 2)
            {
                SettingsScript.Instance.MSAA = 0;
            }
            else if (SettingsScript.Instance.MSAA == 4)
            {
                SettingsScript.Instance.MSAA = 2;
            }
            else if (SettingsScript.Instance.MSAA == 8)
            {
                SettingsScript.Instance.MSAA = 4;
            }
        }
        else if (direction == 1)
        {
            if (SettingsScript.Instance.MSAA == 0)
            {
                SettingsScript.Instance.MSAA = 2;
            }
            else if (SettingsScript.Instance.MSAA == 2)
            {
                SettingsScript.Instance.MSAA = 4;
            }
            else if (SettingsScript.Instance.MSAA == 4)
            {
                SettingsScript.Instance.MSAA = 8;
            }
            else if (SettingsScript.Instance.MSAA == 8)
            {
                SettingsScript.Instance.MSAA = 0;
            }
        }
        SettingsScript.Instance.SetMSAA(SettingsScript.Instance.MSAA);
    }
    // ��ֱͬ��
    public void ToggleVSync()
    {
        SettingsScript.Instance.VSyncEnabled = !SettingsScript.Instance.VSyncEnabled;
        SettingsScript.Instance.SetVSync(SettingsScript.Instance.VSyncEnabled);
    }
    // ���FPS
    public void ToggleMaxFPS(int direction)
    {
        if (direction == 0)
        {
            if (SettingsScript.Instance.MaxFPS == 30)
            {
                SettingsScript.Instance.MaxFPS = -1;
            }
            else if (SettingsScript.Instance.MaxFPS == 60)
            {
                SettingsScript.Instance.MaxFPS = 30;
            }
            else if (SettingsScript.Instance.MaxFPS == 120)
            {
                SettingsScript.Instance.MaxFPS = 60;
            }
            else if (SettingsScript.Instance.MaxFPS == -1)
            {
                SettingsScript.Instance.MaxFPS = 120;
            }
        }
        else if (direction == 1)
        {
            if (SettingsScript.Instance.MaxFPS == -1)
            {
                SettingsScript.Instance.MaxFPS = 30;
            }
            else if (SettingsScript.Instance.MaxFPS == 30)
            {
                SettingsScript.Instance.MaxFPS = 60;
            }
            else if (SettingsScript.Instance.MaxFPS == 60)
            {
                SettingsScript.Instance.MaxFPS = 120;
            }
            else if (SettingsScript.Instance.MaxFPS == 120)
            {
                SettingsScript.Instance.MaxFPS = -1;
            }
        }
        SettingsScript.Instance.SetMaxFPS(SettingsScript.Instance.MaxFPS);
    }
}