using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class CuttableObject : MonoBehaviour
{
    [Title("Data")]
    [SerializeField] CuttableDataSO _cuttableData;
    [SerializeField] int scoreAmount;

    [Title("Object References")]
    [SerializeField] Rigidbody _leftSide = null;
    [SerializeField] Rigidbody _rightSide = null;
    [SerializeField] List<MeshCollider> _partsColliders;
    [SerializeField] BoxCollider _boxCollider = null;

    [Title("Setup")]
    [SerializeField] string cutTag;

    [Title("Control")]
    [SerializeField, ReadOnly] bool isCut;

    public static event Action<int> OnObjectCut;

    public void Cut()
    {
        var cutForce = new Vector3(0f, 0f, _cuttableData.OnCutForce);
        _boxCollider.enabled = false;

        for(int i = 0; i < _partsColliders.Count; i++)
        {
            _partsColliders[i].enabled = true;
        }

        _leftSide.isKinematic = false;
        _rightSide.isKinematic = false;

        _leftSide.AddForce(-cutForce);
        _rightSide.AddForce(cutForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cutTag))
        {
            Cut();
            OnObjectCut?.Invoke(scoreAmount);
        }
    }

    private void ShowScore()
    {

    }
}
