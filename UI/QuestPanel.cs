using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : ToggleablePanel
{
    [SerializeField] private Quest _selectedQuest;
    Step _selectedStep => _selectedQuest.CurrentStep;
    [SerializeField] private TMP_Text _nameObjectivesText;
    [SerializeField] private TMP_Text _currentObjectivesText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _rewardsText;
    [SerializeField] private Image _iconImage;

    [ContextMenu("Bind")]
    public void Bind()
    {
        _iconImage.sprite = _selectedQuest.Sprite;
        _nameObjectivesText.SetText(_selectedQuest.DisplayName);
        _descriptionText.SetText(_selectedQuest.Description);

        DisplayStepObjectives();
    }

    private void DisplayStepObjectives()
    {
        StringBuilder objectivesList = new StringBuilder();
        if (_selectedStep != null)
        {
            objectivesList.AppendLine(_selectedStep.Instuctions);
            foreach (var objective in _selectedStep.Objectives)
            {
                string rgb = objective.IsCompleted ? "green" : "red";
                objectivesList.AppendLine($"<color={rgb}>{objective}</color>");
            }
        }

        _currentObjectivesText.SetText(objectivesList.ToString());
    }

    public void SelectQuest(Quest quest)
    {
        if(_selectedQuest)
            _selectedQuest.Changed -= DisplayStepObjectives;
        
        _selectedQuest = quest;
        Bind();
        Show();

        _selectedQuest.Changed += DisplayStepObjectives;
    }
}
