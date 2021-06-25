using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] GameObject _progressBar;
    [SerializeField] Image _progressFilledImage;
    void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
    }
    private void UpdateHintTextState(bool enabledHint) => _hintText.enabled = enabledHint;
    private void OnDisable() => Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;

    void Update()
    {
        if (InspectionManager.Inspecting)
        {
            _progressFilledImage.fillAmount = Mathf.Clamp01(InspectionManager.InspectionProgress);
            _progressBar.SetActive(true);
        }
        else if (_progressBar.activeSelf)
        {
            _progressBar.SetActive(false);
        }
    }
}