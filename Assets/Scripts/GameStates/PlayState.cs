public class PlayState : IGameState
{
    private Player _player;
    private UI _uI;
    private PlayerInput _input;

    public PlayState(Player player, UI uI, PlayerInput input)
    {
        _player = player;
        _uI = uI;
        _input = input;
    }

    public void Enter()
    {
        _player.Mover.enabled = true;
        _player.AheadMovementRotation.enabled = true;
        _player.MovementDamage.enabled = true;
        _uI.PlayMenu.gameObject.SetActive(true);
        _input.Player.Enable();
    }

    public void Exit()
    {
        _player.Mover.enabled = false;
        _player.AheadMovementRotation.enabled = false;
        _player.MovementDamage.enabled = false;
        _uI.PlayMenu.gameObject.SetActive(false);
        _input.Player.Disable();
    }
}