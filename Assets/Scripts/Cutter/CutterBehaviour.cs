using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UIElements;
using System.ComponentModel.Design;
using System;
using UnityEngine.Assertions.Must;
using Unity.VisualScripting;
using System.Xml;

public class CutterBehaviour : MonoBehaviour
{
    [Title("Data")]
    [SerializeField] CutterDataSO _cutterData = null;

    [Title("Object References")]
    [SerializeField] Rigidbody _rigidBody = null;
    [SerializeField] GameObject _activeBlade = null;

    [Title("Control")]
    [SerializeField, ReadOnly] bool cutterFrozen;

    public bool CutterFrozen
    {
        get => cutterFrozen;
        set => cutterFrozen = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        InputManager.OnClickActionPerformed += LaunchCutter;
        InputManager.OnTouchActionPerformed += LaunchCutter;
    }

    private void OnDestroy()
    {
        InputManager.OnClickActionPerformed -= LaunchCutter;
        InputManager.OnTouchActionPerformed -= LaunchCutter;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody.inertiaTensorRotation = Quaternion.identity;
    }

    [Button]
    public void LaunchCutter(bool direction = true)
    {
        _rigidBody.isKinematic = false;

        _rigidBody.velocity = Vector3.zero;

        if (direction)
        {
            _rigidBody.AddForce(new Vector3(_cutterData.CutterLaunch_XForce, _cutterData.CutterLaunch_YForce, 0f), ForceMode.Impulse);
            RotateCutter();
        }
        else
        {
            _rigidBody.AddForce(new Vector3(-_cutterData.CutterBounce_XForce, _cutterData.CutterBounce_YForce, 0f), ForceMode.Impulse);
            RotateCutter(false);
        }

        StartCoroutine("UnfreezeObject");
    }

    public void Bounce()
    {
        LaunchCutter(false);
    }

    void RotateCutter(bool direction = true)
    {
        Vector3 torque;
        if(direction)
            torque = new Vector3(_cutterData.CutterLaunch_RotationSpeed, 0f, 0f);
        else
            torque = new Vector3(-_cutterData.CutterBounce_RotationSpeed, 0f, 0f);


        _rigidBody.angularVelocity = Vector3.zero;
        _rigidBody.AddRelativeTorque(torque, ForceMode.Acceleration);
    }

    public void FreezeObject()
    {
        if (cutterFrozen) return;

        _rigidBody.isKinematic = true;
        _rigidBody.velocity = Vector3.zero;

        cutterFrozen = true;
    }

    public void InstantUnfreezeObject()
    {
        cutterFrozen = false;
        _rigidBody.isKinematic = false;
    }

    IEnumerator UnfreezeObject()
    {
        yield return new WaitForSeconds(0.5f);

        cutterFrozen = false;
    }
}
