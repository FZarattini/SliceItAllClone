using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UIElements;
using System.ComponentModel.Design;
using System;

public class CutterBehaviour : MonoBehaviour
{
    [Title("Data")]
    [SerializeField] CutterDataSO _cutterData = null;

    [Title("Object References")]
    [SerializeField] SplineManager _splineManager = null;
    [SerializeField] SplineFollower _splineFollower = null;
    [SerializeField] GameObject _activeBlade = null;

    [Title("Control")]
    [SerializeField, ReadOnly] bool enableZRotation;

    // Start is called before the first frame update
    void Start()
    {
        enableZRotation = false;
        _splineFollower.applyDirectionRotation = false;

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
        SplineComputer _splineComputer = _splineFollower.spline;

        _splineManager.PositionSpline(transform.position, _cutterData.CutterHorizontalDistance, _cutterData.CutterVerticalDistance);

        _splineFollower.Restart();
        _splineFollower.RebuildImmediate();

        _splineFollower.followSpeed = _cutterData.CutterMoveSpeed;
        enableZRotation = true;
        _splineFollower.follow = true;
    }

    void RotateCutter()
    {
        var rotationSpeed = _cutterData.CutterRotationSpeed;
        _activeBlade.transform.Rotate(new Vector3(0f, 0f, -rotationSpeed));
    }
}
