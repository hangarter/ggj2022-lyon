using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public TMP_Text scoreLabel;
    public GameObject lavaPlatform;
    public GameObject icePlatform;

    private List<SquarePointCounter> lavaSquares;
    private List<SquarePointCounter> iceSquares;
    private int player1Score;
    private int player2Score;

    // Start is called before the first frame update
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        foreach(Transform child in lavaPlatform.transform)
        {
            //Debug.Log(child.gameObject.GetComponent<SquarePointCounter>());
            child.gameObject.GetComponent<SquarePointCounter>().OnPointScored += TouchedFloor;
        }
        foreach (Transform child in icePlatform.transform)
        {
            //Debug.Log(child.gameObject.GetComponent<SquarePointCounter>());
            child.gameObject.GetComponent<SquarePointCounter>().OnPointScored += TouchedFloor;
        }
    }

    private void Update()
    {
        scoreLabel.text = $"{player1Score} - {player2Score}";
    }

    private void TouchedFloor(SquarePointCounter.FloorType floorType)
    {
        switch (floorType)
        {
            case SquarePointCounter.FloorType.Ice:
                player1Score++;
                break;
            case SquarePointCounter.FloorType.Lava:
                player2Score++;
                break;
        }
    }
}
