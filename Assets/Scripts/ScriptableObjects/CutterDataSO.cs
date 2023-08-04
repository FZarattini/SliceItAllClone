using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutterData", menuName = "ScriptableObjects/CutterDataSO", order = 1)]
public class CutterDataSO : ScriptableObject
{
    public float CutterXForce;
    public float CutterYForce;
    public float CutterRotationSpeed;
}
