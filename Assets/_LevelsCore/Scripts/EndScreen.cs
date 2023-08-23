using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : AnimatedWindowBase
{
    // private SimplePresenter<RectTransform> presenter = new();
    [SerializeField] private Button nextBtn, replayBtn, miniGameBtn;
    [SerializeField] private RectTransform wonElement, deffeateElement;
    private string menuScene = "MainMenu";
    public void Show(LevelModel model)
    {
        //if(model == null) return;
        wonElement.SetActive(model.isWon);
        deffeateElement.SetActive(!model.isWon);
        nextBtn.SetActive(model.isWon);
        nextBtn.OnClick(() =>
        {
            GameSession.Instance.CompleteLevel(model);
            GameSession.Instance.StartGame(model.configs, ++model.levelIdx);
        });
        replayBtn.OnClick(() =>
        {
            WindowManager.Instance.CloseAll();
            GameSession.Instance.StartGame(model.configs, model.levelIdx);
        });
        miniGameBtn.OnClick(() =>
        {
            WindowManager.Instance.CloseAll();
            SceneManager.LoadScene(menuScene);
        });
        // WindowManager.Instance.Show<ClickCounter>();
        // WindowManager.Instance.Show<ClickToStop>();
        // WindowManager.Instance.Show<GuessName>();
    }
}
