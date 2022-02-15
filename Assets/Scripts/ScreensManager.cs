using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public PointsManager pointsManager;
    public GameObject gameplayScreen;
    public GameObject victoryScreen;
    public PlayerInputObserver playerInputObserver;
    public GameObject helios;
    public GameObject selena;
    public GameObject aTie;
    public TMP_Text victoryText;

    public void ShowVictoryScreen()
    {
        playerInputObserver.playerInputs.ForEach(playerInput =>
        {
            playerInput.currentActionMap = playerInput.actions.FindActionMap("Victory Screen Selection");
        });
        gameplayScreen.SetActive(false);
        victoryScreen.SetActive(true);

        if(pointsManager.player1Score > pointsManager.player2Score)
        {
            helios.SetActive(true);
            selena.SetActive(false);
            aTie.SetActive(false);
            victoryText.text = "Helios wins!";
        }

        if (pointsManager.player2Score > pointsManager.player1Score)
        {
            helios.SetActive(false);
            selena.SetActive(true);
            aTie.SetActive(false);
            victoryText.text = "Selena wins!";
        }

        if (pointsManager.player2Score == pointsManager.player1Score)
        {
            helios.SetActive(false);
            selena.SetActive(false);
            aTie.SetActive(true);
            
            victoryText.text = "It's a tie !";
        }
    }
}
