using System.Collections;
using System.Collections.Generic;
using Tools.Reactive;
using UnityEngine;

[System.Serializable]
public class LevelModel
{
    public LevelModel(LevelConfigs configs, int levelIdx)
    {
        this.configs = configs;
        this.levelIdx = levelIdx;
    }
    public LevelConfigs configs;
    public Reactive<int> scores = new Reactive<int>();
    public bool isWon;
    public int levelIdx;
}
