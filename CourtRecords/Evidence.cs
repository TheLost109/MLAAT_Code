using UnityEngine;

[CreateAssetMenu(fileName = "Evidence", menuName = "法庭记录/证物")]
public class Evidence : ScriptableObject
{
    public int id;
    public string Name;
    public string NameCN;
    public int State;
    public Sprite Sprite;
    [TextArea]
    public string Description;
    [TextArea]
    public string Description2;
    [TextArea]
    public string DescriptionCN;
    [TextArea]
    public string Description2CN;
}
