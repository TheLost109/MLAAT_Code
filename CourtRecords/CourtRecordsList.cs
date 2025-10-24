using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "法庭记录", menuName = "法庭记录/记录列表")]
public class CourtRecordsList : ScriptableObject
{
    public List<Evidence> EvidencesList = new List<Evidence>();
    public List<Profile> ProfilesList = new List<Profile>();
}
