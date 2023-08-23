using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;

public class LevelScreen : WindowBase
{
    [SerializeField] private TextMeshProUGUI scoresText;
    public void Show(LevelModel model)
    {
        model.scores.SubscribeAndInvoke(scores => scoresText.text = scores.ToString());
    }
}
