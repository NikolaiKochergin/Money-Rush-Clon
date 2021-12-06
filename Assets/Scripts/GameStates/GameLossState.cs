public class GameLossState : IGameState
{
    private UI _uI;
    private PlayerInput _input;

    public GameLossState(UI uI, PlayerInput input)
    {
        _uI = uI;
        _input = input;
    }

    public void Enter()
    {
        _uI.GameLossMenu.gameObject.SetActive(true);
        _input.UI.RestartGame.Enable();
    }

    public void Exit()
    {
        _uI.GameLossMenu.gameObject.SetActive(false);
        _input.UI.RestartGame.Disable();
    }
}