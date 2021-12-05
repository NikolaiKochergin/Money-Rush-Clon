using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private GameLossMenu _gameLossMenu;
    [SerializeField] private GameFinishedMenu _gameFinishedMenu;

    public MainMenu MainMenu => _mainMenu;
    public GameMenu GameMenu => _gameMenu;
    public GameLossMenu GameLossMenu => _gameLossMenu;
    public GameFinishedMenu GameFinishedMenu => _gameFinishedMenu;
}
