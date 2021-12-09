public class GameLossState : IGameState
{
    private Player _player;
    private UI _uI;
    private PlayerInput _input;

    public GameLossState(Player player, UI uI, PlayerInput input)
    {
        _player = player;
        _uI = uI;
        _input = input;
    }

    public void Enter()
    {
        UnityEngine.Time.timeScale = 0;
        _uI.GameLossMenu.gameObject.SetActive(true);
        _input.UI.RestartGame.Enable();
    }

    public void Exit()
    {
        //_player.ViewModel.enabled = false;
        _uI.GameLossMenu.gameObject.SetActive(false);
        _input.UI.RestartGame.Disable();
    }
}