using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CutterData", menuName = "ScriptableObjects/CutterDataSO", order = 1)]
public class CutterDataSO : ScriptableObject
{
    public float CutterLaunch_XForce;
    public float CutterLaunch_YForce;
    public float CutterBounce_XForce;
    public float CutterBounce_YForce;
    public float CutterLaunch_RotationSpeed;
    public float CutterBounce_RotationSpeed;
}
