using UnityEngine;

public class StartState : IGameState
{
    private Player _player;
    private UI _uI;
    private GameStatesSwitcher _switcher;

    public StartState(Player player, UI uI, GameStatesSwitcher switcher)
    {
        _player = player;
        _uI = uI;
        _switcher = switcher;
    }

    public void Enter()
    {
        _player.ResetPlayer();
        _uI.MainMenu.gameObject.SetActive(true);
        _switcher.PlayerInput.UI.Enable();
        _switcher.PlayerInput.UI.StartGame.performed += ctx => _switcher.SetPlayState();
    }

    public void Exit()
    {
        _uI.MainMenu.gameObject.SetActive(false);
        _switcher.PlayerInput.UI.Disable();
        _switcher.PlayerInput.UI.StartGame.performed -= ctx => _switcher.SetPlayState();
    }
}