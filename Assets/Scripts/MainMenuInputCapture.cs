using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInputCapture : MonoBehaviour
{
    public delegate void NotifyPlayerButtonPressed();

    public event NotifyPlayerButtonPressed OnSelectOptionPressed;
    public event NotifyPlayerButtonPressed OnDownPressed;
    public event NotifyPlayerButtonPressed OnUpPressed;

    private void OnUp()
    {
        if (OnUpPressed != null)
        {
            OnUpPressed();
        }
    }

    private void OnDown()
    {
        if (OnDownPressed != null)
        {
            OnDownPressed();
        }
    }

    private void OnSelectOption()
    {
        if (OnSelectOptionPressed != null)
        {
            OnSelectOptionPressed();
        }
    }
}
