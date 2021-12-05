public class PlayState : IGameState
{
    private Player _player;
    private UI _uI;
    private GameStatesSwitcher _switcher;

    public PlayState(Player player, UI uI, GameStatesSwitcher switcher)
    {
        _player = player;
        _uI = uI;
        _switcher = switcher;
    }

    public void Enter()
    {
        _player.Mover.enabled = true;
        _uI.GameMenu.gameObject.SetActive(true);
        _switcher.PlayerInput.Player.Enable();
        _switcher.PlayerInput.Player.MoveX.performed += ctx => _player.Mover.OnMoveX();
    }

    public void Exit()
    {
        _player.Mover.enabled = false;
        _uI.GameMenu.gameObject.SetActive(false);
        _switcher.PlayerInput.Player.Disable();
        _switcher.PlayerInput.Player.MoveX.performed -= ctx => _player.Mover.OnMoveX();
    }
}