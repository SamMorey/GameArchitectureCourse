using System;
using UnityEngine;

public class MetInspectedCondition : MonoBehaviour, IMet
{
    [SerializeField] Inspectable _requiredInspectable;
    public bool Met() => _requiredInspectable.WasFullyInspected;

    void OnDrawGizmos()
    {
        if (_requiredInspectable != null)
        {
            Gizmos.color = Met() ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position, _requiredInspectable.transform.position);
        }
    }
}