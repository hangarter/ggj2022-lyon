using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputObserver : MonoBehaviour
{
    public List<GameObject> _targetPositions;
    public List<GameObject> _playerSpawningPositions;
    public List<Cannon> _cannons;
    public GameObject ball;
    public GameObject playerPrefab;

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
        var player = Instantiate(playerPrefab, _playerSpawningPositions[_currentPlayerJoinedIndex].transform.position, Quaternion.identity);

        input.GetComponent<PlayerInputCapture>().OnPlayerMove += player.GetComponent<MovePlayer>().OnPlayerMove;
        input.GetComponent<PlayerInputCapture>().OnCannonButtonPressed += _cannons[_currentPlayerJoinedIndex].OnCannonButtonPressed;
        input.GetComponent<PlayerInputCapture>().OnPlayerMove += _cannons[_currentPlayerJoinedIndex].OnCannonMoved;

        _cannons[_currentPlayerJoinedIndex].ball = ball;
        _cannons[_currentPlayerJoinedIndex].ballThrower = player.GetComponent<BallThrower>();
        _cannons[_currentPlayerJoinedIndex].movePlayer = player.GetComponent<MovePlayer>();

        var ballThrower = player.GetComponent<BallThrower>();


        ballThrower.targetPosition = _targetPositions[_currentPlayerJoinedIndex];
        ballThrower.ball = ball;

        _currentPlayerJoinedIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
