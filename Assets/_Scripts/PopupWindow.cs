using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools;

public class PopupWindow : WindowBase
{
    [SerializeField] private Button okBtn;

    public void Show()
    {
        okBtn.OnClick(() => WindowManager.Instance.Close(this));
    }
}