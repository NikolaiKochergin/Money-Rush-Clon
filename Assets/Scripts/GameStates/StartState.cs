public class StartState : IGameState
{
    private LevelLoader _loader;
    private Player _player;
    private UI _uI;
    private PlayerInput _input;

    public StartState(LevelLoader loader, Player player, UI uI, PlayerInput input)
    {
        _loader = loader;
        _player = player;
        _uI = uI;
        _input = input;
    }

    public void Enter()
    {
        _loader.Load();
        _loader.LevelLoaded += OnLevelLoaded;
        _player.SetStartState();
        _uI.MainMenu.gameObject.SetActive(true);
    }

    public void Exit()
    {
        _loader.LevelLoaded -= OnLevelLoaded;
        _uI.MainMenu.gameObject.SetActive(false);
        _input.UI.StartGame.Disable();
    }

    private void OnLevelLoaded()
    {
        _input.UI.StartGame.Enable();
    }
}