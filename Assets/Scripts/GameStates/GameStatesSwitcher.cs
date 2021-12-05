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

    public PlayerInput PlayerInput => _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _player.Mover.Initialization(_input);

        InitStates();
        SetStateByDefault();
    }

    private void OnEnable()
    {
        _player.GameLoss += SetGameLossState;
        _player.GameFinished += SetFinishedState;
    }

    private void OnDisable()
    {
        _player.GameLoss -= SetGameLossState;
        _player.GameFinished -= SetFinishedState;
    }

    public void SetStartState()
    {
        var state = GetState<StartState>();
        SetState(state);
    }

    public void SetPlayState()
    {
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
        var state = GetState<GameLossState>();
        SetState(state);
    }

    private void InitStates()
    {
        _statesMap = new Dictionary<Type, IGameState>();

        _statesMap[typeof(StartState)] = new StartState(_player, _uI, this);
        _statesMap[typeof(PlayState)] = new PlayState(_player, _uI, this);
        _statesMap[typeof(FinishedState)] = new FinishedState(_uI, this);
        _statesMap[typeof(GameLossState)] = new GameLossState(_uI, this);
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