using System.Collections;
using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    private GameData _gameData;
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
    }
}