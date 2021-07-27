using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] TMP_Text _completedInspectionText;
    [SerializeField] GameObject _progressBar;
    [SerializeField] Image _progressFilledImage;
    void OnEnable()
    {
        _hintText.enabled = false;
        _completedInspectionText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
        Inspectable.AnyInspectionCompletion += ShowCompletedInspectionText;
    }

    private void ShowCompletedInspectionText(Inspectable inspectable, string completedInspectionMessage, float displayLength)
    {
        _completedInspectionText.SetText(completedInspectionMessage);
        _completedInspectionText.enabled = true;
        StartCoroutine(FadeCompletedText(displayLength));
    }

    private IEnumerator FadeCompletedText(float displayLength)
    {
        _completedInspectionText.alpha = 1;
        while (_completedInspectionText.alpha > 0)
        {
            yield return null;
            _completedInspectionText.alpha -= Time.deltaTime / displayLength;
        }

        _completedInspectionText.enabled = false;
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