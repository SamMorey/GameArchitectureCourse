using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<Quest> _activeQuests = new List<Quest>();
    [SerializeField] private QuestPanel _questPanel;
    [SerializeField] List<Quest> _allQuests;
    public static QuestManager Instance { get; private set; }

    private void Awake() => Instance = this;


    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
    }

    public void AddQuestByName(string questName)
    {
        var quest = _allQuests.FirstOrDefault(t => t.name == questName);
        if(quest !=null)
            AddQuest(quest);
        else
            Debug.LogError(message:$"Missing quest {questName} attempted to add from dialog");
    }
}