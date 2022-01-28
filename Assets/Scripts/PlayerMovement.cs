using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    private CharacterController _characterController;
    private Vector3 _direction;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _direction = Vector3.zero;
    }

    private void Update()
    {
        _characterController.SimpleMove(_direction * speed);
    }

    private void OnMove(InputValue value)
    {
        var input = value.Get<Vector2>();

        _direction = transform.TransformDirection(new Vector3(-input.y, 0, input.x));
    }
}
