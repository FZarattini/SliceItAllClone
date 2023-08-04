using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UIElements;
using System.ComponentModel.Design;
using System;
using UnityEngine.Assertions.Must;

public class CutterBehaviour : MonoBehaviour
{
    [Title("Data")]
    [SerializeField] CutterDataSO _cutterData = null;

    [Title("Object References")]
    [SerializeField] Rigidbody _rigidBody = null;
    [SerializeField] GameObject _activeBlade = null;

    [Title("Control")]
    [SerializeField, ReadOnly] bool enableZRotation;
    [SerializeField] string endGameTag;

    // Start is called before the first frame update
    void Start()
    {
        enableZRotation = false;

        InputManager.OnClickActionPerformed += LaunchCutter;
        InputManager.OnTouchActionPerformed += LaunchCutter;
        CuttableObject.onObjectCut += FreezeObject;
    }

    private void OnDestroy()
    {
        InputManager.OnClickActionPerformed -= LaunchCutter;
        InputManager.OnTouchActionPerformed -= LaunchCutter;
        CuttableObject.onObjectCut -= FreezeObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableZRotation)
            RotateCutter();
    }

    [Button]
    public void LaunchCutter()
    {
        enableZRotation = true;
        _rigidBody.isKinematic = false;
        _rigidBody.useGravity = true;

        _rigidBody.velocity = Vector3.zero;

        _rigidBody.AddForce(new Vector3(_cutterData.CutterXForce, _cutterData.CutterYForce, 0f), ForceMode.Impulse);
    }

    void RotateCutter()
    {
        var rotationSpeed = _cutterData.CutterRotationSpeed;
        _activeBlade.transform.Rotate(new Vector3(0f, 0f, -rotationSpeed));
    }

    void FreezeObject()
    {
        enableZRotation = false;
        _rigidBody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(endGameTag))
        {
            GameManager.Instance.LoseGame();
        }
    }
}
