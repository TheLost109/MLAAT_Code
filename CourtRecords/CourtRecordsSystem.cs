using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using DG.Tweening;

public class CourtRecordsSystem : MonoBehaviour
{
    // 需单独配置
    public GameBaseController gameBaseController;
    // 预制件中已配置
    public GameObject CourtRecordsPanel;
    public CourtRecordsList CourtRecordsList;
    public GameObject Record1;
    public GameObject Record2;
    public GameObject Record3;
    public GameObject Record4;
    public GameObject Record5;
    public GameObject Record6;
    public GameObject Record7;
    public GameObject Record8;
    public Image Record1Img;
    public Image Record2Img;
    public Image Record3Img;
    public Image Record4Img;
    public Image Record5Img;
    public Image Record6Img;
    public Image Record7Img;
    public Image Record8Img;
    public GameObject Record1Selected;
    public GameObject Record2Selected;
    public GameObject Record3Selected;
    public GameObject Record4Selected;
    public GameObject Record5Selected;
    public GameObject Record6Selected;
    public GameObject Record7Selected;
    public GameObject Record8Selected;
    // 证物名字，描述，大图
    public TMP_Text RecordTitle;
    public TMP_Text RecordDescription;
    public Image RecordBigImage;
    // 当前是证物还是档案
    public string CurrentTag = "Evidence";
    // 证物数量
    private int EvidencesListCount;
    // 任务档案数量
    private int ProfilesListCount;
    // 总计页数
    public int MaxPages = 1;
    // 当前页数
    public int CurrentPage = 1;
    public bool IsPanelHided = true;
    // 法庭记录 信息面板、侧标签
    public GameObject RecordInformation;
    public GameObject RecordTags;
    public GameObject EvidenceTagSelected;
    public GameObject ProfileTagSelected;

    // 单例模式
    //public static CourtRecordsSystem Instance;

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

    private void Update()
    {

    }

    public void PanelTrigger()
    {
        if (!IsPanelHided)
        {
            IsPanelHided = true;
            CourtRecordsPanel.transform.DOLocalMoveY(868, .5f, false).SetEase(Ease.InOutBack);
            Invoke("DelayHide", .51f);
        }
        else
        {
            CancelInvoke();
            GeneratePanelListEvidence();
            ShowPropertiesEvidence(1);
            CourtRecordsPanel.SetActive(true);
            IsPanelHided = false;
            CourtRecordsPanel.transform.DOLocalMoveY(150, .5f, false).SetEase(Ease.InOutBack);
            RecordTags.SetActive(true);
            EvidenceTagSelected.SetActive(true);
            ProfileTagSelected.SetActive(false);
            CurrentTag = "Evidence";
        }
    }
    public void DelayHide()
    {
        CourtRecordsPanel.SetActive(false);
    }
    public void GeneratePanelListEvidence()
    {
        Record1Img.sprite = null;
        Record2Img.sprite = null;
        Record3Img.sprite = null;
        Record4Img.sprite = null;
        Record5Img.sprite = null;
        Record6Img.sprite = null;
        Record7Img.sprite = null;
        Record8Img.sprite = null;
        Record1.SetActive(false);
        Record2.SetActive(false);
        Record3.SetActive(false);
        Record4.SetActive(false);
        Record5.SetActive(false);
        Record6.SetActive(false);
        Record7.SetActive(false);
        Record8.SetActive(false);
        //EvidencesListCount = CourtRecordsList.EvidencesList.Count();
        EvidencesListCount = gameBaseController.RecordsEvidence.Count();
        MaxPages = EvidencesListCount / 8 + 1;
        for (int i = 0; i < EvidencesListCount - (MaxPages - CurrentPage) * 8; i++)
        {
            if (i == 0)
            {
                Record1.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record1Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 1)
            {
                Record2.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record2Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 2)
            {
                Record3.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record3Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 3)
            {
                Record4.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record4Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 4)
            {
                Record5.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record5Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 5)
            {
                Record6.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record6Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 6)
            {
                Record7.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record7Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 7)
            {
                Record8.SetActive(true);
                int id = gameBaseController.RecordsEvidence[i].id;
                Record8Img.sprite = CourtRecordsList.EvidencesList.Find(t => t.id == id).Sprite;
            }
        }
    }
    public void GeneratePanelListProfile()
    {
        Record1Img.sprite = null;
        Record2Img.sprite = null;
        Record3Img.sprite = null;
        Record4Img.sprite = null;
        Record5Img.sprite = null;
        Record6Img.sprite = null;
        Record7Img.sprite = null;
        Record8Img.sprite = null;
        Record1.SetActive(false);
        Record2.SetActive(false);
        Record3.SetActive(false);
        Record4.SetActive(false);
        Record5.SetActive(false);
        Record6.SetActive(false);
        Record7.SetActive(false);
        Record8.SetActive(false);
        //ProfilesListCount = CourtRecordsList.ProfilesList.Count();
        ProfilesListCount = gameBaseController.RecordsProfile.Count();
        MaxPages = ProfilesListCount / 8 + 1;
        for (int i = 0; i < ProfilesListCount - (MaxPages - CurrentPage) * 8; i++)
        {
            if (i == 0)
            {
                Record1.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record1Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 1)
            {
                Record2.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record2Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 2)
            {
                Record3.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record3Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 3)
            {
                Record4.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record4Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 4)
            {
                Record5.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record5Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 5)
            {
                Record6.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record6Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 6)
            {
                Record7.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record7Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
            else if (i == 7)
            {
                Record8.SetActive(true);
                int id = gameBaseController.RecordsProfile[i].id;
                Record8Img.sprite = CourtRecordsList.ProfilesList.Find(t => t.id == id).Sprite;
            }
        }
    }
    public void GetNewEvidence(int id)
    {
        Records rec = new Records();
        rec.id = id;
        rec.state = 0;
        gameBaseController.RecordsEvidence.Add(rec);
    }
    public void DropEvidence(int id)
    {
        Records rec = new Records();
        rec.id = id;
        rec.state = 0;
        gameBaseController.RecordsEvidence.Remove(rec);
    }
    public void GetNewProfile(int id)
    {
        Records rec = new Records();
        rec.id = id;
        rec.state = 0;
        gameBaseController.RecordsProfile.Add(rec);
    }
    public void DropProfile(int id)
    {
        Records rec = new Records();
        rec.id = id;
        rec.state = 0;
        gameBaseController.RecordsProfile.Remove(rec);
    }
    public bool DoIHaveThisEvidence(int id)
    {
        if (gameBaseController.RecordsEvidence.Exists(t => t.id == id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DoIHaveThisProfile(int id)
    {
        if (gameBaseController.RecordsProfile.Exists(t => t.id == id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ShowProperties(int Num)
    {
        if (CurrentTag == "Evidence")
        {
            ShowPropertiesEvidence(Num);
        }
        else
        {
            ShowPropertiesProfile(Num);
        }
    }
    public void ShowPropertiesEvidence(int Num)
    {
        ClearAllSelected();
        ItemSelected(Num);
        int i = (CurrentPage - 1) * 1 + Num - 1;
        print(i);
        int id = gameBaseController.RecordsEvidence[i].id;
        int state = gameBaseController.RecordsEvidence[i].state;
        Evidence Evi = CourtRecordsList.EvidencesList.Find(t => t.id == id);
        if(SettingsScript.Instance.Language == "Chinese")
        {
            RecordTitle.text = Evi.NameCN;
            if (state == 0)
            {
                RecordDescription.text = Evi.DescriptionCN;
            }
            else if (state == 1)
            {

                RecordDescription.text = Evi.Description2CN;
            }
        }
        else
        {
            RecordTitle.text = Evi.Name;
            if (state == 0)
            {
                RecordDescription.text = Evi.Description;
            }
            else if (state == 1)
            {

                RecordDescription.text = Evi.Description2;
            }
        }
        RecordBigImage.sprite = Evi.Sprite;
    }
    public void ShowPropertiesProfile(int Num)
    {
        ClearAllSelected();
        ItemSelected(Num);
        int i = (CurrentPage - 1) * 1 + Num - 1;
        print(i);
        int id = gameBaseController.RecordsProfile[i].id;
        int state = gameBaseController.RecordsProfile[i].state;
        Profile Pro = CourtRecordsList.ProfilesList.Find(t => t.id == id);
        if (SettingsScript.Instance.Language == "Chinese")
        {
            RecordTitle.text = Pro.NameCN;
            if (state == 0)
            {
                RecordDescription.text = Pro.DescriptionCN;
            }
            else if (state == 1)
            {

                RecordDescription.text = Pro.Description2CN;
            }
        }
        else
        {
            RecordTitle.text = Pro.Name;
            if (state == 0)
            {
                RecordDescription.text = Pro.Description;
            }
            else if (state == 1)
            {

                RecordDescription.text = Pro.Description2;
            }
        }
        RecordBigImage.sprite = Pro.Sprite;
    }
    public void ClearAllSelected()
    {
        Record1Selected.SetActive(false);
        Record2Selected.SetActive(false);
        Record3Selected.SetActive(false);
        Record4Selected.SetActive(false);
        Record5Selected.SetActive(false);
        Record6Selected.SetActive(false);
        Record7Selected.SetActive(false);
        Record8Selected.SetActive(false);
    }
    public void ItemSelected(int Num)
    {
        Record1Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record2Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record3Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record4Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record5Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record6Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record7Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        Record8Img.GetComponent<RectTransform>().DOLocalMoveY(0, 0, false);
        if (Num == 1)
        {
            Record1Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record1Selected.SetActive(true);
        }
        else if(Num == 2)
        {
            Record2Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record2Selected.SetActive(true);
        }
        else if (Num == 3)
        {
            Record3Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record3Selected.SetActive(true);
        }
        else if (Num == 4)
        {
            Record4Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record4Selected.SetActive(true);
        }
        else if (Num == 5)
        {
            Record5Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record5Selected.SetActive(true);
        }
        else if (Num == 6)
        {
            Record6Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record6Selected.SetActive(true);
        }
        else if (Num == 7)
        {
            Record7Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record7Selected.SetActive(true);
        }
        else if (Num == 8)
        {
            Record8Img.GetComponent<RectTransform>().DOLocalMoveY(4, 0, false);
            Record8Selected.SetActive(true);
        }
    }
    public void SwitchTag(bool IsProfile)
    {
        if (!IsProfile)
        {
            CurrentTag = "Evidence";
            EvidenceTagSelected.SetActive(true);
            ProfileTagSelected.SetActive(false);
            GeneratePanelListEvidence();
            ShowPropertiesEvidence(1);
        }
        else
        {
            CurrentTag = "Profile";
            EvidenceTagSelected.SetActive(false);
            ProfileTagSelected.SetActive(true);
            GeneratePanelListProfile();
            ShowPropertiesProfile(1);
        }
    }
    public void NewEvidenceShow(int EvidenceId)
    {
        RecordInformation.transform.DOLocalMoveX(1601, 0f, false).SetEase(Ease.InOutBack);
        gameBaseController.Clickable = false;
        GeneratePanelListEvidence();
        ShowPropertiesEvidence(EvidenceId + 1);
        CourtRecordsPanel.SetActive(true);
        CourtRecordsPanel.transform.DOLocalMoveY(150, .5f, false).SetEase(Ease.InOutBack);
        Invoke("NewEvidenceShowDelay", .5f);
        RecordTags.SetActive(false);
        CurrentTag = "Evidence";
    }
    public void NewEvidenceShowDelay()
    {
        RecordInformation.transform.DOLocalMoveX(0, 1f, false).SetEase(Ease.InOutBack);
    }
    public void NewEvidenceHide()
    {
        CourtRecordsPanel.transform.DOLocalMoveY(868, .5f, false).SetEase(Ease.InOutBack);
        Invoke("DelayHide", .51f);
    }
}
