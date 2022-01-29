using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCapture : MonoBehaviour
{
    public delegate void NotifyPlayerMovement(Vector2 value);
    public delegate void NotifyPlayerButtonPressed();

    public event NotifyPlayerMovement OnPlayerMove;
    public event NotifyPlayerButtonPressed OnCannonButtonPressed;

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
            OnPlayerMove(input);
        }
    }

    private void OnCannon(InputValue value)
    {
        if(OnCannonButtonPressed != null)
        {
            OnCannonButtonPressed();
        }
    }
}
