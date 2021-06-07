using System.Collections.Generic;
using UnityEngine;

public class ToggleablePanel : MonoBehaviour
{   
    CanvasGroup _canvasGroup;
    static HashSet<ToggleablePanel> _activePanels = new HashSet<ToggleablePanel>();

    public static bool IsVisable => _activePanels.Count > 0;


    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }
    
    public void Hide()
    {
        _activePanels.Remove(this);
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
    
    public void Show()
    {
        _activePanels.Add(this);
        _canvasGroup.alpha = .5f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}