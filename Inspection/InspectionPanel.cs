using TMPro;
using UnityEngine;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }
    private void UpdateHintTextState(bool enabledHint) => _hintText.enabled = enabledHint;
    private void OnDisable() => Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
}