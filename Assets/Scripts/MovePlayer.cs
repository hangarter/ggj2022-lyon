using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float baseSpeed = 3f;
    public float slowSpeed = 1f;
    public LayerMask platformLayer;
    //public float speed = 1f;
    public bool canMove;
    public Animator animator;

    private CharacterController _characterController;
    private Vector3 _direction;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _direction = Vector3.zero;
    }

    void Update()
    {
        float speed = baseSpeed;
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo, 1f, platformLayer))
        {
            var platform = hitInfo.collider.GetComponent<ChangeMaterial>();
            if (platform.isCorrupt)
            {
                speed = slowSpeed;
            }
        }
        if (canMove)
        {
            _characterController.SimpleMove(_direction * speed);
            animator.SetFloat("MoveSpeed", _direction.magnitude * speed);
        }
        else
        {
            animator.SetFloat("MoveSpeed", 0);
        }
    }

    public void OnPlayerMove(Vector2 value)
    {
        _direction = new Vector3(-value.y, 0, value.x);
    }
}
