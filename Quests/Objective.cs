using System;
using UnityEngine;

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _type;
    [SerializeField] GameFlag _gameFlag;
    public GameFlag GameFlag => _gameFlag;

    [Header("Int Game flags")]
    [Tooltip("Required amount for flag to pass")]
    [SerializeField] int _required;

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }

    public bool IsCompleted
    {
        get
        {
            switch (_type)
            {
                case ObjectiveType.Flag:
                {
                    if (_gameFlag is BoolGameFlag boolGameFlag)
                        return boolGameFlag.Value;
                    if (_gameFlag is IntGameFlag intGameFlag)
                        return intGameFlag.Value >= _required;
                    if (_gameFlag is DecimalGameFlag doubleGameFlag)
                        return doubleGameFlag.Value >= _required;
                    if (_gameFlag is StringGameFlag stringGameFlag)
                        return true;
                    return false;
                }
                default: return false;
            }
        }
    }



    public override string ToString()
    {
        switch (_type)
        {
            case ObjectiveType.Flag:
            {
                if (_gameFlag is BoolGameFlag)
                    return _gameFlag.name;
                if (_gameFlag is IntGameFlag intGameFlag)
                    return $"{intGameFlag.name}  ({intGameFlag.Value}/{_required})";
                if (_gameFlag is DecimalGameFlag doubleGameFlag)
                    return $"{doubleGameFlag.name}  ({doubleGameFlag.Value}/{_required})";
                if (_gameFlag is StringGameFlag stringGameFlag)
                    return stringGameFlag.Value;
                return "Invalid/Unknown gameflag type.";
            }
            default: return _type.ToString();
        }
    }
    
}