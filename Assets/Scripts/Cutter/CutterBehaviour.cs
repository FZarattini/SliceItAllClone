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
        // Resets the inertia tensor to be the coordinate system of the transform
        _rigidBody.inertiaTensorRotation = Quaternion.identity;
    }

    // Launches the Cutter using AddForce on the X and Y axis and applying rotation
    [Button]
    public void LaunchCutter(bool direction = true)
    {
        if (!GameManager.Instance.GameRunning) return;

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

    // Launches the cutter in the opposite direction when the hilt hits a surface
    public void Bounce()
    {
        LaunchCutter(false);
    }

    // Rotates the object using AddTorque
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

    // Freezes the cutter when it gets stuck in a surface
    public void FreezeObject()
    {
        if (cutterFrozen) return;

        _rigidBody.isKinematic = true;
        _rigidBody.velocity = Vector3.zero;

        cutterFrozen = true;
    }

    // Unfreezes the object after a little delay. Makes so the object avoids getting reestuck on the same surface after being launched.
    IEnumerator UnfreezeObject()
    {
        yield return new WaitForSeconds(0.5f);

        cutterFrozen = false;
    }
}
