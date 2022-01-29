using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public delegate void NotifyCannonFired();
    public event NotifyCannonFired OnCannonFired;

    public MovePlayer movePlayer;
    public GameObject ball;
    public float cannonStrength;
    public bool canFire;
    public float minPositionX = -4.5f;
    public float maxPositionX = -0.28f;
    public float speed = 2f;

    private Rigidbody _ballRigidBody;
    private float movement;
    private BallThrower ballThrower;


    void Start()
    {

        canFire = false;
        _ballRigidBody = ball.GetComponent<Rigidbody>();
        ballThrower = GetComponent<BallThrower>();
    }

    private void Update()
    {
        if (canFire)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(Mathf.Clamp(transform.position.x - movement, minPositionX, maxPositionX), transform.position.y, transform.position.z),
                speed * Time.deltaTime
                );
        }
        movePlayer.canMove = !canFire;
    }

    internal void OnCannonButtonPressed()
    {
        if (canFire)
        {
            ball.transform.parent = null;
            _ballRigidBody.isKinematic = false;
            _ballRigidBody.detectCollisions = true;
            ballThrower.ThrowBall();
            canFire = false;
            if(OnCannonFired != null)
            {
                OnCannonFired();
            }
        }
    }

    internal void OnCannonMoved(Vector2 value)
    {
        if (canFire)
        {
            movement = value.y;
        }   
    }
}
