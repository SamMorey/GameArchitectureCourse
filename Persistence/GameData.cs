using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<GameFlagData> GameFlagDatas;
    public List<InspectableData> InspectableDatas;

    public GameData()
    {
        GameFlagDatas = new List<GameFlagData>();
        InspectableDatas = new List<InspectableData>();
        //GameFlagDatas.Add(new GameFlagData(){Value = "Jason 1", Name = "flagname"});
    }
}