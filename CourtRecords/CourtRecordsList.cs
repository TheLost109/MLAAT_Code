using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "��ͥ��¼", menuName = "��ͥ��¼/��¼�б�")]
public class CourtRecordsList : ScriptableObject
{
    public List<Evidence> EvidencesList = new List<Evidence>();
    public List<Profile> ProfilesList = new List<Profile>();
}
