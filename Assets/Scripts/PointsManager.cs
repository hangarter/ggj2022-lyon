using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SquarePointCounter;

public class PointsManager : MonoBehaviour
{
    public delegate void NotifyPointScored(FloorType floorType);
    public event NotifyPointScored OnPointScored;

    public TMP_Text scoreLabel;
    public GameObject lavaPlatform;
    public GameObject icePlatform;
    public Cannon cannonPlayer1;
    public Cannon cannonPlayer2;

    private List<SquarePointCounter> lavaSquares;
    private List<SquarePointCounter> iceSquares;
    private bool canScore;
    private int player1Score;
    private int player2Score;

    // Start is called before the first frame update
    void Start()
    {
        canScore = true;
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

        cannonPlayer1.OnCannonFired += OnCannonFired;
        cannonPlayer2.OnCannonFired += OnCannonFired;
    }

    private void OnCannonFired()
    {
        canScore = true;
    }

    private void Update()
    {
        scoreLabel.text = $"{player1Score} - {player2Score}";
    }

    private void TouchedFloor(SquarePointCounter.FloorType floorType)
    {
        if (!canScore) return;
        canScore = false;

        Debug.Log("Collision");

        switch (floorType)
        {
            case SquarePointCounter.FloorType.Ice:
                player1Score++;
                break;
            case SquarePointCounter.FloorType.Lava:
                player2Score++;
                break;
        }

        if(OnPointScored != null)
        {
            OnPointScored(floorType);
        }
    }
}
