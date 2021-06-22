using System;
using TMPro;
using UnityEngine;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] TMP_Text _progressText;
    void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }
    private void UpdateHintTextState(bool enabledHint) => _hintText.enabled = enabledHint;
    private void OnDisable() => Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;

    void Update()
    {
        if(InspectionManager.Inspecting)
            _progressText.SetText(InspectionManager.InspectionProgress.ToString());
    }
}