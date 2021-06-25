using System;
using System.Collections;
using UnityEngine;
[Serializable]
public class GamePersistence : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    void Start() => LoadGameFlags();
    private void OnDisable() => SaveGameFlags();
    private void SaveGameFlags()
    {
        var json =JsonUtility.ToJson(_gameData);
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
    }

    private void LoadGameFlags()
    {
        string json = PlayerPrefs.GetString("GameData");
        _gameData = JsonUtility.FromJson<GameData>(json);
        if (_gameData == null)
        {
            _gameData = new GameData();
        }
        FlagManager.Instance.Bind(_gameData.GameFlagDatas);
        InspectionManager.Bind(_gameData.InspectableDatas);
    }
}