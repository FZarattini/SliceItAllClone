using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class CuttableObject : MonoBehaviour
{
    [Title("Object References")]
    [SerializeField] Rigidbody _leftSide = null;
    [SerializeField] Rigidbody _rightSide = null;
    [SerializeField] BoxCollider _boxCollider = null;

    [Title("Setup")]
    [SerializeField] string cutTag;

    //public delegate void OnObjectCut();
    //public static OnObjectCut onObjectCut;
    public static Action onObjectCut;

    public void Cut()
    {
        _leftSide.isKinematic = false;
        _rightSide.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cutTag))
        {
            _boxCollider.enabled = false;
            Cut();
            onObjectCut?.Invoke();
        }
    }
}
