using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    [SerializeField] float _timeToInspect = 3f;
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();
    float _timeInspected;
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public float InspectionProgress => _timeInspected / _timeToInspect;

    public static event Action<bool> InspectablesInRangeChanged; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inspectablesInRange.Remove(this);
            InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        }
    }

    public void Inspect()
    {
        _timeInspected += Time.deltaTime;
        if (_timeInspected > _timeToInspect)
        {
            CompleteInspection();
        }
    }

    void CompleteInspection()
    {
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        gameObject.SetActive(false);
    }
}