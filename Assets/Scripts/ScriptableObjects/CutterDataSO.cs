using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutterData", menuName = "ScriptableObjects/CutterDataSO", order = 1)]
public class CutterDataSO : ScriptableObject
{
    public float CutterMoveSpeed;
    public float CutterRotationSpeed;
    public float CutterHorizontalDistance;
    public float CutterVerticalDistance;
}
