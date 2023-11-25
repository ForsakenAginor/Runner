using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _stepSize;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxYPosition;
    [SerializeField] private float _minYPosition;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        var epsilon = 0.000001f;

        if (_targetPosition.y + epsilon < _maxYPosition)
            ChangeTargetPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        var epsilon = 0.000001f;

        if (_targetPosition.y - epsilon > _minYPosition)
            ChangeTargetPosition(-_stepSize);
    }

    private void ChangeTargetPosition(float changeValue)
    {
        _targetPosition.y += changeValue;
    }
}
