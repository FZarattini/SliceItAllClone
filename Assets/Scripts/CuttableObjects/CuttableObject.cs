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
    [SerializeField] TagDataSO _tagData;

    [Title("Object References")]
    [SerializeField] Rigidbody _leftSide = null;
    [SerializeField] Rigidbody _rightSide = null;
    [SerializeField] List<MeshCollider> _partsColliders;
    [SerializeField] BoxCollider _boxCollider = null;
    [SerializeField] TextMesh _scoreText = null;


    [Title("Control")]
    [SerializeField, ReadOnly] bool isCut;

    public static event Action<int> OnObjectCut;

    void Cut()
    {
        var cutForce = new Vector3(0f, 0f, _cuttableData.OnCutForce);
        _boxCollider.enabled = false;

        for(int i = 0; i < _partsColliders.Count; i++)
        {
            _partsColliders[i].enabled = true;
        }

        _leftSide.isKinematic = false;
        _rightSide.isKinematic = false;

        _leftSide.AddForce(cutForce);
        _rightSide.AddForce(-cutForce);
        ShowScore();

        OnObjectCut?.Invoke(scoreAmount);
    }

    public void ShowScore()
    {
        _scoreText.text = $"+{scoreAmount}";
        _scoreText.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCut) return;

        if (other.CompareTag(_tagData.BladeTag))
        {
            isCut = true;
            Cut();
        }
    }
}
