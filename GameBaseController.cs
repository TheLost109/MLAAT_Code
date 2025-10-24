using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBaseController : MonoBehaviour
{
    // 角色姓名Object
    public GameObject NameText;
    // 对话内容Object
    public GameObject DialogText;
    // 区域介绍Object
    public GameObject NewAreaText;
    // 台词位置
    public int DialogIndex = 0;
    // 台词行
    public string[] DialogRows;
    // 章节ID
    public int ChapterID = 0;
    // 区域ID
    public int AreaID = 0;
    // 点击音效
    public AudioSource ClickSFX;
    // 男说话音效
    public AudioSource SpeechSFXMale;
    // 女说话音效
    public AudioSource SpeechSFXFemale;
    // 区域介绍打字音效
    public AudioSource NewAreaSFX;
    // 本句话是否静音
    private bool IsSilent = false;
    // 打字机效果延迟
    private float Delay;
    // 当前文本
    private string CurrentText;
    // 用于控制角色Sprite是否动嘴型
    public bool IsCharacterTalking = false;
    // 当前是否可点击进行下一句
    public bool Clickable = false;
    // 最后一个字符
    private char LastChar;
    // 血量
    public int Health = 10;
    // 当前音乐
    public string CurrentMusic = "";
    // 当前背景
    public string CurrentBG = "";
    // 对话者性别
    private int Gender;
    // 对话状态
    public bool DialogProcessing = false;
    // 事件ID
    public int EventID = 0;
    // 底部按钮
    public GameObject SettingsButton;
    // 继续游戏
    public bool Proceed = false;
    // 法庭记录-证物
    public List<Records> RecordsEvidence = new List<Records>();
    // 法庭记录-档案
    public List<Records> RecordsProfile = new List<Records>();
    // 说话音效速度
    public float TalkingSFXSpeed = 0.08f;

    private void Start()
    {

    }
    private void Update()
    {
        // 当前是否可存档
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
        Debug.Log("对话读取成功");
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
    // 对话执行完毕后，将IsCharacterTalking标记为false
    public void FinishedTalking()
    {
        IsCharacterTalking = false;
        DialogProcessing = false;
    }
    // 遍历文本产生打字机效果
    public void ShowText(string _text, float delay)
    {
        string text = _text.Replace("\\n", "\n");
        string text2 = _text.Replace("\\n", "");
        int stopPos = text2.IndexOf("<s></s>");
        var t = DOTween.To(()=>string.Empty, value => DialogText.GetComponent<TMP_Text>().text = value, text, delay * _text.Length).SetEase(Ease.Linear).SetId("SpeechAnim");
        // 富文本
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
    // 展示新区域
    public void ShowArea(string _text, float delay)
    {
        string text = _text.Replace("\\n", "\n"); ;
        var t = DOTween.To(() => string.Empty, value => NewAreaText.GetComponent<TMP_Text>().text = value, text, delay * _text.Length).SetEase(Ease.Linear).SetId("NewAreaAnim");
        // 富文本
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
