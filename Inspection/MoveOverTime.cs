using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOverTime : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    [SerializeField] Vector3 _magnitude = Vector3.down;
    [SerializeField] AnimationCurve _curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    
    Vector3 _startingPostition;
    Vector3 _endingPosition;
    float _elapsed;

    void Awake() => _startingPostition = transform.position;
    private void OnEnable()
    {
        _elapsed = 0f;
        _endingPosition = _startingPostition + _magnitude;
    }
    private void OnDisable() => transform.position = _startingPostition;

    void Update()
    {
        _elapsed += Time.deltaTime;
        float pctElapsed = _elapsed / duration;
        float pctOnCurve = _curve.Evaluate(pctElapsed);
        transform.position = Vector3.Lerp(_startingPostition, _endingPosition, pctOnCurve);
    }
}
