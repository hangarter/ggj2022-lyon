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
                break;
            case SquarePointCounter.FloorType.Ice:
                ball.transform.position = spawningPointPlayer1.transform.position;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
