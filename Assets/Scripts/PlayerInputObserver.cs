using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputObserver : MonoBehaviour
{
    public List<GameObject> _targetPositions;

    public List<SpawningPosition> _playerSpawningPositions;
    public List<AudioClip> playerHittingSounds;
    public List<PlayerInput> playerInputs;

    public List<Cannon> _cannons;
    public GameObject ball;

    private int _currentPlayerJoinedIndex;
    private PlayerInputManager _playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        _currentPlayerJoinedIndex = 0;
        _playerInputManager = GetComponent<PlayerInputManager>();

        _playerInputManager.onPlayerJoined += OnPlayerJoined;
        _playerInputManager.onPlayerLeft += OnPlayerLeft;

    }

    private void OnPlayerLeft(PlayerInput input)
    {
        Debug.Log($"Player {input.GetInstanceID()} left!");
    }

    private void OnPlayerJoined(PlayerInput input)
    {
        var spawningPosition = _playerSpawningPositions[_currentPlayerJoinedIndex];

        var player = Instantiate(spawningPosition.playerPrefab, spawningPosition.transform.position, spawningPosition.transform.rotation);

        if (playerInputs == null) playerInputs = new List<PlayerInput>();
        playerInputs.Add(input);

        var playHittingSound = player.GetComponent<PlayHittingSound>();

        playHittingSound.hittingSound = playerHittingSounds[_currentPlayerJoinedIndex];

        var movePlayer = player.GetComponent<MovePlayer>();

        input.GetComponent<PlayerInputCapture>().OnPlayerMove += movePlayer.OnPlayerMove;
        input.GetComponent<PlayerInputCapture>().OnCannonButtonPressed += _cannons[_currentPlayerJoinedIndex].OnCannonButtonPressed;
        input.GetComponent<PlayerInputCapture>().OnPlayerMove += _cannons[_currentPlayerJoinedIndex].OnCannonMoved;

        _cannons[_currentPlayerJoinedIndex].ball = ball;
        _cannons[_currentPlayerJoinedIndex].movePlayer = player.GetComponent<MovePlayer>();

        var ballThrower = player.GetComponent<BallThrower>();

        switch (_currentPlayerJoinedIndex)
        {
            case 0:
                ballThrower.throwDirection = BallThrower.ThrowDirection.Left;
                break;
            case 1:
                ballThrower.throwDirection = BallThrower.ThrowDirection.Right;
                break;
        }

        ballThrower.targetPosition = _targetPositions[_currentPlayerJoinedIndex];
        ballThrower.ball = ball;

        _currentPlayerJoinedIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
