using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TagData", menuName = "ScriptableObjects/TagDataSO", order = 1)]
public class TagDataSO : ScriptableObject
{
    public string CuttableTag;
    public string CuttablePartTag;
    public string BladeTag;
    public string HiltTag;
}
