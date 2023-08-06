using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds the player Cutter Object reference inside the level generated in runtime
public class LevelReferences : MonoBehaviour
{
    [SerializeField] CutterBehaviour _cutterBehaviour;

    public CutterBehaviour CutterBehaviour => _cutterBehaviour;
}
