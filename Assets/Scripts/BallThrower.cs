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
    public ThrowDirection throwDirection;

    private Rigidbody _ballRigidBody;
    private bool _canHitBall;
    private Animator _animator;

    public AudioSource tickSource;

    public enum ThrowDirection
    {
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        _canHitBall = true;
        _ballRigidBody = ball.GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private Vector3 ForceDirection()
    {
        return ((targetPosition.transform.position.normalized - transform.position.normalized) /*+ Vector3.up * upStrength*/) * (generalStrength);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag.Equals("Ball") && _canHitBall)
        {
            ThrowBall();
        }
    }

    public void ThrowBall()
    {
        Debug.Log(transform.forward);

        if (CompareTag("Player"))
        {
            _animator.SetBool("IsThrowing", true);
        }

        switch (throwDirection)
        {
            case ThrowDirection.Left:
                _ballRigidBody.AddForce(new Vector3(0, .3f, 1f) * generalStrength, ForceMode.Impulse);
                break;
            case ThrowDirection.Right:
                _ballRigidBody.AddForce(new Vector3(0, .3f, -1f) * generalStrength, ForceMode.Impulse);
                break;
                tickSource.Play();
        }
        _canHitBall = false;
        Task.Run(() =>
        {
            Task.Delay(3000);
            _canHitBall = true;
        });
    }
}
