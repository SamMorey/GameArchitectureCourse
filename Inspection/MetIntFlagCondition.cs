using UnityEngine;

public class MetIntFlagCondition : MonoBehaviour, IMet
{
    [SerializeField] IntGameFlag _requiredFlag;
    [SerializeField] int _minVal = default; 
    public bool Met() => _requiredFlag.Value >= _minVal;
}