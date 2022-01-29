using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallThrower : MonoBehaviour
{
    public GameObject targetPosition;
    public GameObject ball;
    public float generalStrength = 2f;
    public float upStrength = 1.4f;

    private Rigidbody _ballRigidBody;
    private bool _firstHit
        ;
    // Start is called before the first frame update
    void Start()
    {
        _firstHit = true;
        _ballRigidBody = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && _firstHit)
        {
            _ballRigidBody.AddForce(ForceDirection(), ForceMode.Impulse);
            _firstHit = false;
        }


    }

    private Vector3 ForceDirection()
    {
        return ((targetPosition.transform.position.normalized - transform.position.normalized) + Vector3.up * upStrength) * generalStrength;
    }
}
