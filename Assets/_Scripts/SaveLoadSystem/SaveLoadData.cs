using System;
using System.Collections.Generic;

[Serializable]
public class SaveLoadData
{
    public StoredValue<int> MaxScore;
    public StoredValue<int> CurrentLevelIndex;

    public SaveLoadData()
    {
        MaxScore = new StoredValue<int>(0);
        CurrentLevelIndex = new StoredValue<int>(1);
    }
}