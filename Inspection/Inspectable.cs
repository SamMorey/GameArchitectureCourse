using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    public bool WasFullyInspected => InspectionProgress >=1;
    public bool MeetsConditions => _required == null || _required.WasFullyInspected;
    public static event Action<bool> InspectablesInRangeChanged; 
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public float InspectionProgress => _data.TimeInspected / _timeToInspect;

    [SerializeField] float _timeToInspect = 3f;
    [SerializeField] UnityEvent OnInspectionCompleted;
    [SerializeField] Inspectable _required;
    InspectableData _data;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !WasFullyInspected && MeetsConditions)
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_inspectablesInRange.Remove(this))
                InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        }
    }

    public void Inspect()
    {
        if(WasFullyInspected)
            return;
        
        _data.TimeInspected += Time.deltaTime;
        if (_data.TimeInspected > _timeToInspect)
        {
            CompleteInspection();
        }
    }

    void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
    }

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if(_data.TimeInspected >= _timeToInspect)
            CompleteInspection();
    }
}