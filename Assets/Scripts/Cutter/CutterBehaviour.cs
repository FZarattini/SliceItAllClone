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

    // Start is called before the first frame update
    void Start()
    {
        enableZRotation = false;

        InputManager.OnClickActionPerformed += LaunchCutter;
        InputManager.OnTouchActionPerformed += LaunchCutter;
    }

    private void OnDestroy()
    {
        InputManager.OnClickActionPerformed -= LaunchCutter;
        InputManager.OnTouchActionPerformed -= LaunchCutter;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableZRotation)
            RotateCutter();
    }

    [Button]
    public void LaunchCutter()
    {

        enableZRotation = true;
        _rigidBody.isKinematic = false;
        _rigidBody.AddForce(new Vector3(_cutterData.CutterXForce, _cutterData.CutterYForce, 0f), ForceMode.Impulse);
    }

    void RotateCutter()
    {
        var rotationSpeed = _cutterData.CutterRotationSpeed;
        _activeBlade.transform.Rotate(new Vector3(0f, 0f, -rotationSpeed));
    }
}
