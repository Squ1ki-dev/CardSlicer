using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelConfig")]
public class LevelConfigs : ScriptableObject
{
    public string configName;
    public string sceneName;
    public List<LevelConfig> levels;
}
[System.Serializable]
public class LevelConfig
{
    public BaseLevelView levelView;
}