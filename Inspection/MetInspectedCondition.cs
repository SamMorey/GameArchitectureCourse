using UnityEngine;

public class MetInspectedCondition : MonoBehaviour, IMet
{
    [SerializeField] Inspectable _requiredInspectable;
    public bool Met() => _requiredInspectable.WasFullyInspected;
}