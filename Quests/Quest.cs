using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public event Action Changed;
    [SerializeField] string _displayName;
    [SerializeField] string _decription;
    [SerializeField] private Sprite _sprite;
    [Tooltip("Notes for Designer")] 
    [SerializeField] string _notes;
    
    int _currentStepIndex;

    public List<Step> Steps;
    public string Description => _decription;
    public string DisplayName => _displayName;
    public Sprite Sprite => _sprite;
    public Step CurrentStep => Steps[_currentStepIndex];

    void OnEnable()
    {
        _currentStepIndex = 0;
        foreach (var step in Steps)
        {
            foreach (var objective in step.Objectives)
            {
                if (objective.GameFlag != null)
                {
                    objective.GameFlag.Changed += HandleFlagChanged;
                }
            }
        }
    }

    void HandleFlagChanged()
    {
        TryProgress();
        Changed?.Invoke();

    }

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Changed?.Invoke();
            // Do what we do when a quest progresses
        }
    }

    
    private Step GetCurrentStep() => Steps[_currentStepIndex];
}

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
    public string Instuctions => _instructions;
    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted()
    {
        return Objectives.TrueForAll(t => t.IsCompleted);
    }
}