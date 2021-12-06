using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PlayMenu _playMenu;
    [SerializeField] private GameLossMenu _gameLossMenu;
    [SerializeField] private GameFinishedMenu _gameFinishedMenu;

    public MainMenu MainMenu => _mainMenu;
    public PlayMenu PlayMenu => _playMenu;
    public GameLossMenu GameLossMenu => _gameLossMenu;
    public GameFinishedMenu GameFinishedMenu => _gameFinishedMenu;
}
