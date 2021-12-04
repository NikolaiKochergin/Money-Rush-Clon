using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UI _uI;

    private PlayerInput _input;
    private Dictionary<Type, IGameState> _statesMap;
    private IGameState _currentState;

    private void Awake()
    {
        _input = new PlayerInput();

        InitStates();
        SetStateByDefault();
    }

    private void OnEnable()
    {
        _input.UI.StartGame.performed += ctx => SetPlayState();
    }

    private void OnDisable()
    {
        _input.UI.StartGame.performed -= ctx => SetPlayState();
    }

    public void SetStartState()
    {
        _input.Player.Disable();
        var state = GetState<StartState>();
        SetState(state);
    }

    public void SetPlayState()
    {
        _input.UI.Disable();
        _input.Player.Enable();
        var state = GetState<PlayState>();
        SetState(state);
    }

    public void SetFinishedState()
    {
        var state = GetState<FinishedState>();
        SetState(state);
    }

    public void SetGameLossState()
    {
        _input.Player.Disable();
        var state = GetState<GameLossState>();
        SetState(state);
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IGameState>();

        _statesMap[typeof(StartState)] = new StartState();
        _statesMap[typeof(PlayState)] = new PlayState();
        _statesMap[typeof(FinishedState)] = new FinishedState();
        _statesMap[typeof(GameLossState)] = new GameLossState();
    }

    private void SetState(IGameState newState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }

    private void SetStateByDefault()
    {
        SetStartState();
    }

    private IGameState GetState<T>() where T : IGameState
    {
        var type = typeof(T);
        return _statesMap[type];
    }
}