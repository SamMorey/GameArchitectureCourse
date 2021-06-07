using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;


public class DialogController : ToggleablePanel
{
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;
    Story _story;

    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset dialog)
    {
        _story = new Story(dialog.text);
        RefeshView();
    }

    void RefeshView()
    {
        Show();
        StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());
            HandleTags();
        }

        _storyText.SetText(storyTextBuilder);
        if(_story.currentChoices.Count == 0 )
            Hide();
        else
            ShowChoices();
    }

    private void ShowChoices()
    {
        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            button.gameObject.SetActive(i < _story.currentChoices.Count);
            button.onClick.RemoveAllListeners();
            if (i < _story.currentChoices.Count)
            {
                var choice = _story.currentChoices[i];
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefeshView();
                });
            }
        }
    }

    void HandleTags()
    {
        foreach (var tag in _story.currentTags)
        {
            Debug.Log(tag);
            if (tag.StartsWith("E."))
            {
                string eventName = tag.Remove(0, 2);
                GameEvent.RaiseEvent(eventName);
            }
            if (tag.StartsWith("Q."))
            {
                string questName = tag.Remove(0, 2);
                QuestManager.Instance.AddQuestByName(questName);
            }
        }
    }

}