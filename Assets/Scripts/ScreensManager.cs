using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public GameObject gameplayScreen;
    public GameObject victoryScreen;
    public PlayerInputObserver playerInputObserver;

    public void ShowVictoryScreen()
    {
        playerInputObserver.playerInputs.ForEach(playerInput =>
        {
            playerInput.currentActionMap = playerInput.actions.FindActionMap("Victory Screen Selection");
        });
        gameplayScreen.SetActive(false);
        victoryScreen.SetActive(true);
    }
}
