using UnityEngine;

public class TSSoundsManager : MonoBehaviour
{
    // 音乐
    // 魔术之子
    public AudioWithIntro ChildOfMagic;
    // 章节完成（GS1）
    public AudioSource JingleGS1;
    // 电话铃声（成步堂龙一）
    public AudioSource RingtonePW;
    // 悬念
    public AudioWithIntro Suspense;
    // 悬念intro渐入渐出
    public MusicFade SuspenseIntroFade;
    // 悬念loop渐入渐出
    public MusicFade SuspenseLoopFade;

    // 音效
    // 好可疑
    public AudioSource AyashiiSFX;
    // 吓一跳
    public AudioSource BikkuriSFX;
    // 受打击
    public AudioSource DamageSFX;
    // 爆炸
    public AudioSource ExplodeSFX;
    // 物品弹出
    public AudioSource ItemPopSFX;
    // 物品消失
    public AudioSource ItemVanishSFX;
    // 踢
    public AudioSource KickSFX;
    // 切断
    public AudioSource KiriSFX;
    // 新法庭记录
    public AudioSource NewRecordsSFX;
    // 拿起电话
    public AudioSource PickUpSFX;
    // 无语
    public AudioSource SweatSFX;

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