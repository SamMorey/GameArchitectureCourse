using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<GameFlagData> GameFlagDatas;

    public GameData()
    {
        GameFlagDatas = new List<GameFlagData>();
        //GameFlagDatas.Add(new GameFlagData(){Value = "Jason 1", Name = "flagname"});
    }
}