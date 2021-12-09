using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private LevelLoader _loader;
    [SerializeField] private Player _player;
    [SerializeField] private UI _uI;

    private PlayerInput _input;
    private Dictionary<Type, IGameState> _statesMap;
    private IGameState _currentState;

    private void Awake()
    {
        _input = new PlayerInput();
        _player.Mover.Initialization(_input);

        InitStates();
        SetStateByDefault();
    }

    private void OnEnable()
    {
        _input.UI.StartGame.performed += ctx => SetPlayState();
        _input.UI.RestartGame.performed += ctx => SetStartState();

        _player.Cash.GameLoss += SetGameLossState;
        _player.CollisionHandler.GameFinished += SetFinishedState;
    }

    private void OnDisable()
    {
        _player.Cash.GameLoss -= SetGameLossState;
        _player.CollisionHandler.GameFinished -= SetFinishedState;
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

        _statesMap[typeof(StartState)] = new StartState(_loader, _player, _uI, _input);
        _statesMap[typeof(PlayState)] = new PlayState(_player, _uI, _input);
        _statesMap[typeof(FinishedState)] = new FinishedState(_player, _uI, _input);
        _statesMap[typeof(GameLossState)] = new GameLossState(_player, _uI, _input);
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