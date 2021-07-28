using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    public bool WasFullyInspected => InspectionProgress >=1;
    public static event Action<bool> InspectablesInRangeChanged;
    public static event Action<Inspectable, string, float> AnyInspectionCompletion; 
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public float InspectionProgress => _data?.TimeInspected  ?? 0f / _timeToInspect;
    IMet[] _allConditions;

    [SerializeField] float _timeToInspect = 3f;
    [SerializeField] UnityEvent OnInspectionCompleted;
    [SerializeField, TextArea] string _completedInspectionText;
    [SerializeField] float _inspectionTextDisplayLength = 3f;
    [SerializeField] bool _requireMinigame;
    InspectableData _data;

    void Awake() => _allConditions = GetComponents<IMet>();
    public bool MeetsConditions()
    {
        foreach (var condition in _allConditions)
        {
            if (condition.Met() == false)
                return false;
        }
        return true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !WasFullyInspected && MeetsConditions())
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
        if (WasFullyInspected)
        {
            if (_requireMinigame)
                MinigameManager.Instance.StartMinigame(CompleteInspection);
            else
            {
                CompleteInspection();
            }
        }
    }

    void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted?.Invoke();
        AnyInspectionCompletion?.Invoke(this, _completedInspectionText, _inspectionTextDisplayLength);
    }

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if(WasFullyInspected)
            RestoreInspectionState();
    }

    void RestoreInspectionState()
    {
        OnInspectionCompleted?.Invoke();
    }
}