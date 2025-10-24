using UnityEngine;

public class TSSpritesManager : MonoBehaviour
{
    // 对话框
    public GameObject dialogBox;
    // 对话框上方名称标签
    public GameObject NameTag;
    // 对话文本
    public GameObject SpeechText;
    // 区域介绍文本
    public GameObject NewAreaText;

    // 背景图片 - 纯白
    public GameObject WhiteScreen;
    // 背景图片 - 成步堂法律事务所
    public GameObject OfficeBG;
    // 背景图片 - 暮光的卧室
    public GameObject TwilightsBedroom;

    // 证物弹出窗口
    public GameObject ItemHolder;
    // 证物图片 - 成步堂的手机
    public GameObject WrightPhoneSpr;
    // 证物图片 - 给小小马驹的小马指南
    public GameObject TheFilliesGuideToPonies;

    // 精灵 暮光 普通站立、开心站立、困惑站立、恐慌站立、Oops坐下、解释站立、吓我一跳站立、What站立、难过坐下、害怕站立
    public GameObject TwilightStandNormal;
    public GameObject TwilightStandHappy;
    public GameObject TwilightStandConfused;
    public GameObject TwilightStandPanic;
    public GameObject TwilightSitOops;
    public GameObject TwilightStandExplain;
    public GameObject TwilightStandStartled;
    public GameObject TwilightStandWhat;
    public GameObject TwilightSitSad;
    public GameObject TwilightStandScared;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}