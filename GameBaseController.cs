using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBaseController : MonoBehaviour
{
    // ��ɫ����Object
    public GameObject NameText;
    // �Ի�����Object
    public GameObject DialogText;
    // �������Object
    public GameObject NewAreaText;
    // ̨��λ��
    public int DialogIndex = 0;
    // ̨����
    public string[] DialogRows;
    // �½�ID
    public int ChapterID = 0;
    // ����ID
    public int AreaID = 0;
    // �����Ч
    public AudioSource ClickSFX;
    // ��˵����Ч
    public AudioSource SpeechSFXMale;
    // Ů˵����Ч
    public AudioSource SpeechSFXFemale;
    // ������ܴ�����Ч
    public AudioSource NewAreaSFX;
    // ���仰�Ƿ���
    private bool IsSilent = false;
    // ���ֻ�Ч���ӳ�
    private float Delay;
    // ��ǰ�ı�
    private string CurrentText;
    // ���ڿ��ƽ�ɫSprite�Ƿ�����
    public bool IsCharacterTalking = false;
    // ��ǰ�Ƿ�ɵ��������һ��
    public bool Clickable = false;
    // ���һ���ַ�
    private char LastChar;
    // Ѫ��
    public int Health = 10;
    // ��ǰ����
    public string CurrentMusic = "";
    // ��ǰ����
    public string CurrentBG = "";
    // �Ի����Ա�
    private int Gender;
    // �Ի�״̬
    public bool DialogProcessing = false;
    // �¼�ID
    public int EventID = 0;
    // �ײ���ť
    public GameObject SettingsButton;
    // ������Ϸ
    public bool Proceed = false;
    // ��ͥ��¼-֤��
    public List<Records> RecordsEvidence = new List<Records>();
    // ��ͥ��¼-����
    public List<Records> RecordsProfile = new List<Records>();
    // ˵����Ч�ٶ�
    public float TalkingSFXSpeed = 0.08f;

    private void Start()
    {

    }
    private void Update()
    {
        // ��ǰ�Ƿ�ɴ浵
        if (Clickable)
        {
            SettingsButton.SetActive(true);
        }
        else
        {
            SettingsButton.SetActive(false);
        }
    }

    public void UpdateText()
    {
        DOTween.Kill("SpeechAnim");
        DOTween.Kill("NewAreaAnim");
        string[] cells = DialogRows[DialogIndex].Split(',');
        NameText.GetComponent<TMP_Text>().text = cells[2];
        DialogText.GetComponent<TMP_Text>().text = cells[3];
        NewAreaText.GetComponent<TMP_Text>().text = cells[3];
        FinishedTalking();
    }
    public void ReadText(TextAsset _textAsset)
    {
        DialogRows = _textAsset.text.Split('\n');
        Debug.Log("�Ի���ȡ�ɹ�");
    }
    public void ShowDialogRow()
    {
        NameText.GetComponent<TMP_Text>().text = "";
        DialogText.GetComponent<TMP_Text>().text = "";
        NewAreaText.GetComponent<TMP_Text>().text = "";
        DialogProcessing = true;
        string[] cells = DialogRows[DialogIndex].Split(',');
        print(cells[0]);
        NameText.GetComponent<TMP_Text>().text = cells[2];
        Delay = float.Parse(cells[4]);
        if (int.Parse(cells[5]) == 1)
        {
            IsSilent = true;
        }
        else if (int.Parse(cells[5]) == 0)
        {
            IsSilent = false;
        }
        if (int.Parse(cells[0]) == 0)
        {
            ShowArea(cells[3], float.Parse(cells[4]));
            StartCoroutine(NewAreaSFXs(float.Parse(cells[4])));
        }
        else
        {
            if (!IsSilent)
            {
                Gender = int.Parse(cells[1]);
                StartCoroutine(TalkingSFX(Gender, TalkingSFXSpeed));
                ShowText(cells[3], float.Parse(cells[4]));
            }
            else
            {
                ShowText(cells[3], float.Parse(cells[4]));
            }
        }
        int StopPos = cells[3].IndexOf("<s></s>");
        if (StopPos != -1)
        {
            Invoke("FinishedTalking", Delay * cells[3].Length + 1f);
        }
        else
        {
            Invoke("FinishedTalking", Delay * cells[3].Length);
        }
    }
    // �Ի�ִ����Ϻ󣬽�IsCharacterTalking���Ϊfalse
    public void FinishedTalking()
    {
        IsCharacterTalking = false;
        DialogProcessing = false;
    }
    // �����ı��������ֻ�Ч��
    public void ShowText(string _text, float delay)
    {
        string text = _text.Replace("\\n", "\n");
        string text2 = _text.Replace("\\n", "");
        int stopPos = text2.IndexOf("<s></s>");
        var t = DOTween.To(()=>string.Empty, value => DialogText.GetComponent<TMP_Text>().text = value, text, delay * _text.Length).SetEase(Ease.Linear).SetId("SpeechAnim");
        // ���ı�
        t.SetOptions(true);
        if (stopPos != -1)
        {
            if(delay == 0.1f)
            {
                Invoke("PauseText", (stopPos + 3) * delay);
                Invoke("UnpauseText", (stopPos + 3) * delay + 1f);
            }
            else if (delay == 0.05f)
            {
                Invoke("PauseText", (stopPos - 6) * delay);
                Invoke("UnpauseText", (stopPos - 6) * delay + 1f);
            }
        }
    }
    public void PauseText()
    {
        DOTween.Pause("SpeechAnim");
        StopAllCoroutines();
    }
    public void UnpauseText()
    {
        DOTween.Play("SpeechAnim");
        StartCoroutine(TalkingSFX(Gender, TalkingSFXSpeed));
    }
    // չʾ������
    public void ShowArea(string _text, float delay)
    {
        string text = _text.Replace("\\n", "\n"); ;
        var t = DOTween.To(() => string.Empty, value => NewAreaText.GetComponent<TMP_Text>().text = value, text, delay * _text.Length).SetEase(Ease.Linear).SetId("NewAreaAnim");
        // ���ı�
        t.SetOptions(true);
    }
    public void ClicktoNext()
    {
        if (Clickable)
        {
            if (DialogProcessing)
            {
                StopAllCoroutines();
                CancelInvoke();
                UpdateText();
            }
            else
            {
                EventID = EventID + 1;
                Proceed = true;
                ClickSFX.Play();
            }
        }
    }
    IEnumerator TalkingSFX(int gender, float delay)
    {
        while (DialogProcessing)
        {
            if (gender == 0)
            {
                SpeechSFXFemale.Play();
                yield return new WaitForSeconds(delay);
            }
            else if (gender == 1)
            {
                SpeechSFXMale.Play();
                yield return new WaitForSeconds(delay);
            }
        }
    }
    IEnumerator NewAreaSFXs(float delay)
    {
        while (DialogProcessing)
        {
            NewAreaSFX.Play();
            yield return new WaitForSeconds(delay);
        }
    }
}
