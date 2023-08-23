using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : WindowBase
{
    [SerializeField] private Button cardGameBtn, invBtn, shopBtn;
    [SerializeField] private LevelConfigs labyrinthLevelConfigs;//carsLevelConfigs, bottleLevelConfigs, candyLevelConfigs,
    public void Show()
    {
        invBtn.OnClick(() => WindowManager.Instance.Show<PopupWindow>().Show());
        shopBtn.OnClick(() => WindowManager.Instance.Show<PopupWindow>().Show());
        SubscribeBtn(cardGameBtn, labyrinthLevelConfigs);

        void SubscribeBtn(Button btn, LevelConfigs configs)
        {
            btn.OnClick(() => GameSession.Instance.StartGame(configs));
        }
    }
}
