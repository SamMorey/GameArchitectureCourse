using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    [SerializeField]List<GameFlag> _allFlags;
    Dictionary<string, GameFlag> _allFlagsDict = new Dictionary<string, GameFlag>();
    public static FlagManager Instance { get; private set; }

    void Awake() => Instance = this;
    void Start() =>
        _allFlagsDict = _allFlags.ToDictionary(k => Regex.Replace(k.name, @"\s+", ""),
            v => v);
    void OnValidate() => _allFlags = GameUtils.GetAllInstances<GameFlag>();
    public void Set(string flagName, string value)
    {
        if (_allFlagsDict.TryGetValue(flagName, out GameFlag flag) == false)
        {
            Debug.LogError($"Flage not found {flagName}");
            return;
        }

        if (flag is IntGameFlag intGameFlag)
        {
            if(int.TryParse(value, out  var  intGameValue))
                intGameFlag.Set(intGameValue);
        }
        else if (flag is BoolGameFlag boolGameFlag)
        {
            if(bool.TryParse(value, out  var  boolGameValue))
                boolGameFlag.Set(boolGameValue);
        }
        else if (flag is StringGameFlag stringGameFlag)
        {
            stringGameFlag.Set(value);
        }
        else if (flag is DecimalGameFlag decimalGameFlag)
        {
            if(decimal.TryParse(value, out  var  decimalGameValue))
                decimalGameFlag.Set(decimalGameValue);
        }
    }
}
