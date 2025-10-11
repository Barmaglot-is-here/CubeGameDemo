using System;
using UnityEngine;

public class DistanceTracker
{
    private readonly float _targetDistance;
    private readonly Action _onDistanceCovered;
    private readonly Transform _startPoint;

    private Transform _target;

    public DistanceTracker(Transform startPoint, float targetDistance, 
                           Action onDistanceCovered)
    {
        _startPoint         = startPoint;
        _targetDistance     = targetDistance;  
        _onDistanceCovered  = onDistanceCovered;
    }

    public void SetTarget(Transform target) => _target = target;

    public void Update()
    {
        var distanceTraveled    = _startPoint.transform.position.x 
                                - _target.transform.position.x;
        distanceTraveled        = Math.Abs(distanceTraveled);

        if (distanceTraveled >= _targetDistance)
            _onDistanceCovered?.Invoke();
    }
}