using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 1f;

    private CharacterController _characterController;
    private Vector3 _direction;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _direction = Vector3.zero;
    }

    void Update()
    {
        _characterController.SimpleMove(_direction * speed);
    }

    public void OnPlayerMove(Vector2 value)
    {
        _direction = new Vector3(-value.y, 0, value.x);
    }
}
