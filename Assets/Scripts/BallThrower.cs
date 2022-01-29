using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallThrower : MonoBehaviour
{
    public GameObject targetPosition;
    public GameObject ball;
    public float generalStrength = 2f;
    public float upStrength = 1.4f;
    public Vector3 startPosition;

    private Rigidbody _ballRigidBody;
    private bool _canHitBall;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = startPosition;
        _canHitBall = true;
        _ballRigidBody = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.spaceKey.isPressed && _canHitBall)
        //{
        //    _ballRigidBody.AddForce(ForceDirection(), ForceMode.Impulse);
        //    _canHitBall = false;
        //}
    }

    private Vector3 ForceDirection()
    {
        return ((targetPosition.transform.position.normalized - transform.position.normalized) + Vector3.up * upStrength) * generalStrength;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag.Equals("Ball") && _canHitBall)
        {
            _ballRigidBody.AddForce(ForceDirection(), ForceMode.Impulse);
            _canHitBall = false;
            Task.Run(() => {
                Task.Delay(3000);
                _canHitBall = true;
            });
        }
    }
}
