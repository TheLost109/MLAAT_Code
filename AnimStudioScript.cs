using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnimStudioScript : MonoBehaviour
{
    public GameObject SceneCanvas;
    public AudioSource EnterAnimStudioSFX;

    public GameObject AnimStudioHall;
    public GameObject BlackScreen;
    public GameObject BtnTS;
    public GameObject BtnMLI;
    public GameObject BtnEoJ;

    public GameObject LineNoise;
    public GameObject LineNoise2;

    public GameObject TSBtnMask;
    public GameObject MLIBtnMask;
    public GameObject EoJBtnMask;

    public Vector4 BtnMaskPadding0;
    public Vector4 BtnMaskPadding441;

    public GameObject TSPreviewImg;
    public GameObject MLIPreviewImg;
    public GameObject MLIPreviewVideo;
    public RenderTexture MLIPreviewVideoRT;
    public GameObject EoJPreviewImg;
    public GameObject EoJPreviewVideo;
    public RenderTexture EoJPreviewVideoRT;

    public AudioSource ExitAnimStudioSFX;

    public GameObject EnterVideoTS;
    public RenderTexture gs4hammer;
    public AudioSource GS4HammerSFX;

    private bool Loading = true;
    private bool InOtherScene = false;
    public bool BackFromScene = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LineNoiseMove();
        EnterHall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Loading && !InOtherScene)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            {
                ExitHall();
            }
        }
        if (InOtherScene && BackFromScene){
            InOtherScene = false;
            BackFromScene = false;
            SceneCanvas.SetActive(true);
            Loading = true;
            EnterHall();
        }
    }

    public void EnterHall()
    {
        EnterAnimStudioSFX.Play();
        BlackScreen.GetComponent<Image>().DOFade(0, 1f);
        AnimStudioHall.GetComponent<RectTransform>().DOScale(new Vector3(1.75f, 1.75f, 1.75f), .5f);
        Invoke("EnterHall2", 1f);
        Invoke("ButtonsEnter", 1.5f);
        Invoke("SceneReady", 2f);
    }
    public void EnterHall2()
    {
        AnimStudioHall.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), .5f);
        BlackScreen.SetActive(false);
    }

    public void ButtonsEnter()
    {
        BtnTS.GetComponent<RectTransform>().DOLocalMoveX(0, .5f);
        BtnMLI.GetComponent<RectTransform>().DOLocalMoveX(0, .7f);
        BtnEoJ.GetComponent<RectTransform>().DOLocalMoveX(0, .9f);
    }
    public void SceneReady()
    {
        Loading = false;
    }
    public void ExitHall()
    {
        Loading = true;
        ExitAnimStudioSFX.Play();
        BtnTS.GetComponent<RectTransform>().DOLocalMoveX(-640, .5f);
        BtnMLI.GetComponent<RectTransform>().DOLocalMoveX(-640, .5f);
        BtnEoJ.GetComponent<RectTransform>().DOLocalMoveX(-640, .5f);
        AnimStudioHall.GetComponent<RectTransform>().DOScale(new Vector3(2, 2, 2), .6f);
        BlackScreen.SetActive(true);
        BlackScreen.GetComponent<Image>().DOFade(1, .7f);
        Invoke("ExitHallDelay", .8f);
    }

    public void ExitHallDelay()
    {
        GameObject Melody_intro = GameObject.Find("ANewEraBegins2024_Melody_Intro");
        GameObject Melody_loop = GameObject.Find("ANewEraBegins2024_Melody_Loop");
        ChapSelectScripts ChapSelectScript = GameObject.Find("ChapSelectScript").GetComponent<ChapSelectScripts>();
        ChapSelectScript.InAnimStudio = false;
        Melody_intro.GetComponent<MusicFade>().FadeIn();
        Melody_loop.GetComponent<MusicFade>().FadeIn();
        SceneManager.UnloadSceneAsync("AnimStudio");
    }

    public void LineNoiseMove()
    {
        LineNoise.GetComponent<RectTransform>().DOLocalMoveY(-824, 5f).SetEase(Ease.Linear).SetLoops(-1);
        LineNoise2.GetComponent<RectTransform>().DOLocalMoveY(0, 5f).SetEase(Ease.Linear).SetLoops(-1);
    }

    public void BtnSelected(string BtnName)
    {
        float time = .2f;
        if (BtnName == "TS")
        {
            DOTween.Kill("TSBtnHoverAnim");
            TSBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            TSBtnMask.SetActive(true);
            DOTween.To(() => TSBtnMask.GetComponent<RectMask2D>().padding, x => TSBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("TSBtnHoverAnim");

            ClearPreviewImg();
            TSPreviewImg.SetActive(true);
        }
        else if (BtnName == "MLI")
        {
            DOTween.Kill("MLIBtnHoverAnim");
            MLIBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            MLIBtnMask.SetActive(true);
            DOTween.To(() => MLIBtnMask.GetComponent<RectMask2D>().padding, x => MLIBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("MLIBtnHoverAnim");

            ClearPreviewImg();
            MLIPreviewImg.SetActive(true);
            MLIPreviewVideoRT.Release();
            MLIPreviewVideo.SetActive(true);
        }
        else if (BtnName == "EoJ")
        {
            DOTween.Kill("EoJBtnHoverAnim");
            EoJBtnMask.GetComponent<RectMask2D>().padding = BtnMaskPadding441;
            EoJBtnMask.SetActive(true);
            DOTween.To(() => EoJBtnMask.GetComponent<RectMask2D>().padding, x => EoJBtnMask.GetComponent<RectMask2D>().padding = x, BtnMaskPadding0, time).SetId("EoJBtnHoverAnim");

            ClearPreviewImg();
            EoJPreviewImg.SetActive(true);
            EoJPreviewVideoRT.Release();
            EoJPreviewVideo.SetActive(true);
        }
    }
    public void BtnDeSelect(string BtnName)
    {
        if (BtnName == "TS")
        {
            TSBtnMask.SetActive(false);
        }
        else if (BtnName == "MLI")
        {
            MLIBtnMask.SetActive(false);
        }
        else if (BtnName == "EoJ")
        {
            EoJBtnMask.SetActive(false);
        }
    }

    public void ClearPreviewImg()
    {
        TSPreviewImg.SetActive(false);
        MLIPreviewImg.SetActive(false);
        MLIPreviewVideo.SetActive(false);
        EoJPreviewImg.SetActive(false);
        EoJPreviewVideo.SetActive(false);
    }
    public void EnterTS()
    {
        BlackScreen.SetActive(true);
        gs4hammer.Release();
        EnterVideoTS.SetActive(true);
        EnterVideoTS.GetComponent<VideoPlayer>().Play();
        Invoke("PlayGS4HammerSFX", .4f);
        Invoke("EnterScale", 1f);
        Invoke("EnterTS2", 1.6f);
    }
    public void PlayGS4HammerSFX()
    {
        GS4HammerSFX.Play();
    }

    public void EnterScale()
    {
        BtnTS.GetComponent<RectTransform>().DOLocalMoveX(-640, .5f);
        BtnMLI.GetComponent<RectTransform>().DOLocalMoveX(-640, .5f);
        BtnEoJ.GetComponent<RectTransform>().DOLocalMoveX(-640, .5f);
        BlackScreen.GetComponent<Image>().DOFade(1, .5f);
        AnimStudioHall.GetComponent<RectTransform>().DOScale(new Vector3(2, 2, 2), .5f);
    }
    public void EnterTS2()
    {
        EnterVideoTS.SetActive(false);
        InOtherScene = true;
        SceneCanvas.SetActive(false);
        SceneManager.LoadScene("AnimStudio_TS", LoadSceneMode.Additive);
    }
}
