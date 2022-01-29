using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCapture : MonoBehaviour
{
    public delegate void NotifyPlayerMovement(Vector2 value);

    public event NotifyPlayerMovement OnPlayerMove;

    private PlayerInput _playerInput;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnMove(InputValue value)
    {
        var input = value.Get<Vector2>();

        if(OnPlayerMove != null)
        {
            Debug.Log(input);
            OnPlayerMove(input);
        }
    }
}
