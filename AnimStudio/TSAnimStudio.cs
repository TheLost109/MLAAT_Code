using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class TSAnimStudio : MonoBehaviour
{
    public int CurrentCharacter = 0;
    public int CurrentMove = 0;
    public int CurrentVoice = 0;
    public int SelectedBtn = 0;
    public bool RefreshSelection = true;
    public bool ShowingList = false;

    public GameObject BtnCharacters;
    public GameObject BtnCharactersIcon;
    public GameObject BtnCharactersText;
    public GameObject BtnMovements;
    public GameObject BtnMovementsIcon;
    public GameObject BtnMovementsText;
    public GameObject BtnVoicelines;
    public GameObject BtnVoicelinesIcon;
    public GameObject BtnVoicelinesText;

    public Sprite BtnIdleSpr;
    public Sprite BtnSelectedSpr;
    public Sprite Character0;

    public AudioSource PWYoungObjectionJP;
    public AudioSource PWYoungObjectionEN;
    public AudioSource PWYoungObjectionCHS;
    public AudioSource PWYoungTakeThatJP;
    public AudioSource PWYoungTakeThatEN;
    public AudioSource PWYoungTakeThatCHS;
    public AudioSource PWYoungHoldItJP;
    public AudioSource PWYoungHoldItEN;
    public AudioSource PWYoungHoldItCHS;

    public GameObject BubblesMask;
    public GameObject BubbleObjectionCHS;
    public GameObject BubbleTakeThatCHS;
    public GameObject BubbleHoldItCHS;

    public GameObject ListsMask;
    public GameObject CharactersList;
    public GameObject MovementsList;
    public GameObject VoicelinesList;

    public AudioSource BackSFX;
    public AudioSource KetteiSFX;
    public AudioSource MenuSFX;
    public AudioSource SelectSFX;
    public AudioSource PunchDeskSFX;

    public GameObject PWSprNormal;
    public GameObject PWSprPunchDesk;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ����Ŀǰѡ�еİ�ť
        if (RefreshSelection)
        {
            RefreshSelection = false;
            ResetButtonsStat();
            if (SelectedBtn == 0)
            {
                BtnCharacters.GetComponent<Image>().sprite = BtnSelectedSpr;
                BtnCharactersText.GetComponent<TMP_Text>().color = Color.black;
                BtnCharacters.GetComponent<RectTransform>().DOLocalMoveY(64, .25f).SetEase(Ease.Linear);
            }
            else if (SelectedBtn == 1)
            {
                BtnMovements.GetComponent<Image>().sprite = BtnSelectedSpr;
                BtnMovementsText.GetComponent<TMP_Text>().color = Color.black;
                BtnMovements.GetComponent<RectTransform>().DOLocalMoveY(64, .25f).SetEase(Ease.Linear);
            }
            else if (SelectedBtn == 2)
            {
                BtnVoicelines.GetComponent<Image>().sprite = BtnSelectedSpr;
                BtnVoicelinesText.GetComponent<TMP_Text>().color = Color.black;
                BtnVoicelines.GetComponent<RectTransform>().DOLocalMoveY(64, .25f).SetEase(Ease.Linear);
            }
        }
        if (CurrentCharacter == 0)
        {
            BtnCharactersIcon.GetComponent<Image>().sprite = Character0;
            BtnCharactersText.GetComponent<TMP_Text>().text = "�ɲ��� ��һ ��8��ǰ��";
        }
        // T���򿪲˵�
        if (Input.GetKeyDown(KeyCode.T))
        {
            ListsToggle();
        }
        // Z��
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (ShowingList)
            {
                ListsToggle();
            }
            else
            {
                ExitScene();
            }
        }
        // �򿪲˵�
        if (ShowingList)
        {
            if (SelectedBtn == 0)
            {
                ListsMask.SetActive(true);
                CharactersList.SetActive(true);
            }
            else if (SelectedBtn == 1)
            {
                ListsMask.SetActive(true);
                MovementsList.SetActive(true);
            }
            else if (SelectedBtn == 2)
            {
                ListsMask.SetActive(true);
                VoicelinesList.SetActive(true);
            }
        }
        else
        {
            ListsMask.SetActive(false);
            CharactersList.SetActive(false);
            MovementsList.SetActive(false);
            VoicelinesList.SetActive(false);
        }
        // �任��������Ϣ
        if (CurrentMove == 0)
        {
            BtnMovementsText.GetComponent<TMP_Text>().text = "1��һ��";
        }
        else if (CurrentMove == 1)
        {
            BtnMovementsText.GetComponent<TMP_Text>().text = "2������";
        }
        // �任��������Ϣ
        if (CurrentVoice == 0)
        {
            BtnVoicelinesIcon.GetComponent<Image>().sprite = Character0;
            BtnVoicelinesText.GetComponent<TMP_Text>().text = "1�����ԣ�";
        }
        else if(CurrentVoice == 1)
        {
            BtnVoicelinesIcon.GetComponent<Image>().sprite = Character0;
            BtnVoicelinesText.GetComponent<TMP_Text>().text = "2���������";
        }
        else if (CurrentVoice == 2)
        {
            BtnVoicelinesIcon.GetComponent<Image>().sprite = Character0;
            BtnVoicelinesText.GetComponent<TMP_Text>().text = "3���ȵȣ�";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchBtnL();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchBtnR();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayCurrentBtn();
        }
    }

    public void ClickBtn(int btnNum)
    {
        ShowingList = false;
        if (btnNum != SelectedBtn)
        {
            SelectSFX.Play();
            SelectedBtn = btnNum;
            RefreshSelection = true;
        }
        else if (btnNum == 0)
        {
            KetteiSFX.Play();
        }
        else if (btnNum == 1)
        {
            KetteiSFX.Play();
            PlayMove();
        }
        else if (btnNum == 2)
        {
            PlayVoice();
        }
    }
    public void SwitchBtnL()
    {
        SelectSFX.Play();
        if (SelectedBtn == 0)
        {
            SelectedBtn = 2;
        }
        else if (SelectedBtn == 1)
        {
            SelectedBtn = 0;
        }
        else if (SelectedBtn == 2)
        {
            SelectedBtn = 1;
        }
        RefreshSelection = true;
    }
    public void SwitchBtnR()
    {
        SelectSFX.Play();
        if (SelectedBtn == 0)
        {
            SelectedBtn = 1;
        }
        else if (SelectedBtn == 1)
        {
            SelectedBtn = 2;
        }
        else if (SelectedBtn == 2)
        {
            SelectedBtn = 0;
        }
        RefreshSelection = true;
    }
    public void PlayCurrentBtn()
    {
        ClickBtn(SelectedBtn);
    }
    public void ResetButtonsStat()
    {
        BtnCharacters.GetComponent<Image>().sprite = BtnIdleSpr;
        BtnMovements.GetComponent<Image>().sprite = BtnIdleSpr;
        BtnVoicelines.GetComponent<Image>().sprite = BtnIdleSpr;
        BtnCharactersText.GetComponent<TMP_Text>().color = Color.white;
        BtnMovementsText.GetComponent<TMP_Text>().color = Color.white;
        BtnVoicelinesText.GetComponent<TMP_Text>().color = Color.white;
        BtnCharacters.GetComponent<RectTransform>().DOLocalMoveY(0, .25f).SetEase(Ease.Linear);
        BtnMovements.GetComponent<RectTransform>().DOLocalMoveY(0, .25f).SetEase(Ease.Linear);
        BtnVoicelines.GetComponent<RectTransform>().DOLocalMoveY(0, .25f).SetEase(Ease.Linear);
    }
    public void PlayMove()
    {
        PWSprNormal.SetActive(false);
        PWSprPunchDesk.SetActive(false);
        if (CurrentMove == 0)
        {
            PWSprNormal.SetActive(true);
        }
        else if (CurrentMove == 1)
        {
            PWSprPunchDesk.SetActive(true);
            PunchDeskSFX.Play();
        }
    }
    public void PlayVoice()
    {
        CancelInvoke("HideBubbles");
        HideBubbles();
        BubblesMask.SetActive(true);
        if (SettingsScript.Instance.VoiceLang == "Japanese")
        {
            if(CurrentVoice == 0)
            {
                BubbleObjectionCHS.SetActive(true);
                PWYoungObjectionJP.Play();
            }
            else if (CurrentVoice == 1)
            {
                BubbleTakeThatCHS.SetActive(true);
                PWYoungTakeThatJP.Play();
            }
            else if (CurrentVoice == 2)
            {
                BubbleHoldItCHS.SetActive(true);
                PWYoungHoldItJP.Play();
            }
        }
        else if (SettingsScript.Instance.VoiceLang == "English")
        {
            if (CurrentVoice == 0)
            {
                BubbleObjectionCHS.SetActive(true);
                PWYoungObjectionEN.Play();
            }
            else if (CurrentVoice == 1)
            {
                BubbleTakeThatCHS.SetActive(true);
                PWYoungTakeThatEN.Play();
            }
            else if (CurrentVoice == 2)
            {
                BubbleHoldItCHS.SetActive(true);
                PWYoungHoldItEN.Play();
            }
        }
        else if (SettingsScript.Instance.VoiceLang == "Chinese")
        {
            if (CurrentVoice == 0)
            {
                BubbleObjectionCHS.SetActive(true);
                PWYoungObjectionCHS.Play();
            }
            else if (CurrentVoice == 1)
            {
                BubbleTakeThatCHS.SetActive(true);
                PWYoungTakeThatCHS.Play();
            }
            else if (CurrentVoice == 2)
            {
                BubbleHoldItCHS.SetActive(true);
                PWYoungHoldItCHS.Play();
            }
        }
        Invoke("HideBubbles", 2f);
    }
    public void HideBubbles()
    {
        BubblesMask.SetActive(false);
        BubbleObjectionCHS.SetActive(false);
        BubbleTakeThatCHS.SetActive(false);
        BubbleHoldItCHS.SetActive(false);
    }
    public void SelectCharacter(int num)
    {
        KetteiSFX.Play();
        CurrentCharacter = num;
        ShowingList = false;
    }
    public void SelectMovement(int num)
    {
        CurrentMove = num;
        KetteiSFX.Play();
        PlayMove();
        ShowingList = false;
    }
    public void SelectVoiceline(int num)
    {
        CurrentVoice = num;
        PlayVoice();
        ShowingList = false;
    }
    public void ListsToggle()
    {
        MenuSFX.Play();
        ShowingList = !ShowingList;
    }

    public void ExitScene()
    {
        GameObject AnimStudioScriptObj = GameObject.Find("AnimStudioScript");
        AnimStudioScript animStudioScript = AnimStudioScriptObj.GetComponent<AnimStudioScript>();
        animStudioScript.BackFromScene = true;
        SceneManager.UnloadSceneAsync("AnimStudio_TS");
    }
}
