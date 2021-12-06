public class StartState : IGameState
{
    private Player _player;
    private UI _uI;
    private PlayerInput _input;

    public StartState(Player player, UI uI, PlayerInput input)
    {
        _player = player;
        _uI = uI;
        _input = input;
    }

    public void Enter()
    {
        _player.SetStartState();
        _uI.MainMenu.gameObject.SetActive(true);
        _input.UI.StartGame.Enable();
    }

    public void Exit()
    {
        _uI.MainMenu.gameObject.SetActive(false);
        _input.UI.StartGame.Disable();
    }
}