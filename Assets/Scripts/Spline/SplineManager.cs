using Dreamteck.Splines;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineManager : MonoBehaviour
{
    [Title("Spline References")]
    [SerializeField] SplineComputer _splineComputer;
    [SerializeField, ReadOnly] SplinePoint[] _splinePoints;

    public Action OnSplineEndedAction = null;

    public SplinePoint[] SplinePoints => _splinePoints;


    // Start is called before the first frame update
    void Start()
    {
        _splinePoints = _splineComputer.GetPoints();
    }

    public void PositionSpline(Vector3 initialPosition, float horizontalDistance, float verticalDistance)
    {
        var middlePointIndex = _splinePoints.Length / 2;
        var finalPointIndex = _splinePoints.Length - 1;

        _splinePoints[0].position = initialPosition;
        _splinePoints[middlePointIndex].position = initialPosition + new Vector3(horizontalDistance / 2f, verticalDistance, 0f);
        _splinePoints[finalPointIndex].position = initialPosition + new Vector3(horizontalDistance, 0f, 0f);

        _splineComputer.SetPoints(_splinePoints);
        _splineComputer.RebuildImmediate();
    }

    public void OnSplineEnded()
    {
        OnSplineEndedAction?.Invoke();
    }
}
