using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReferences : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutterBehaviour;

    public CutterBehaviour CutterBehaviour => _cutterBehaviour;
}
