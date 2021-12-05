public class GameLossState : IGameState
{
    private UI _uI;
    private GameStatesSwitcher _switcher;

    public GameLossState(UI uI, GameStatesSwitcher switcher)
    {
        _uI = uI;
        _switcher = switcher;
    }

    public void Enter()
    {
        _uI.GameLossMenu.gameObject.SetActive(true);
        _switcher.PlayerInput.UI.Enable();
        _switcher.PlayerInput.UI.StartGame.performed += ctx => _switcher.SetStartState();
    }

    public void Exit()
    {
        _uI.GameLossMenu.gameObject.SetActive(false);
        _switcher.PlayerInput.UI.Disable();
        _switcher.PlayerInput.UI.StartGame.performed -= ctx => _switcher.SetStartState();
    }
}