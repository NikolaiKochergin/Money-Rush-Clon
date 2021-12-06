public class FinishedState : IGameState
{
    private UI _uI;
    private PlayerInput _input;

    public FinishedState(UI uI, PlayerInput input)
    {
        _uI = uI;
        _input = input;
    }

    public void Enter()
    {
        _uI.GameFinishedMenu.gameObject.SetActive(true);
        _input.UI.RestartGame.Enable();
    }

    public void Exit()
    {
        _uI.GameFinishedMenu.gameObject.SetActive(false);
        _input.UI.RestartGame.Disable();
    }
}