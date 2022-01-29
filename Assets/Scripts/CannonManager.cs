using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    public PointsManager pointsManager;
    public GameObject ball;
    public GameObject spawningPointPlayer1;
    public GameObject spawningPointPlayer2;
    public Cannon player1Cannon;
    public Cannon player2Cannon;

    void Start()
    {
        pointsManager.OnPointScored += OnPointScored;
    }

    private void OnPointScored(SquarePointCounter.FloorType floorType)
    {
        var rigidbody = ball.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        rigidbody.detectCollisions = false;
        switch (floorType)
        {
            case SquarePointCounter.FloorType.Lava:
                ball.transform.position = spawningPointPlayer2.transform.position;
                player2Cannon.canFire = true;
                ball.transform.parent = player2Cannon.transform;
                break;
            case SquarePointCounter.FloorType.Ice:
                ball.transform.position = spawningPointPlayer1.transform.position;
                player1Cannon.canFire = true;
                ball.transform.parent = player1Cannon.transform;

                break;
        }
    }

}
