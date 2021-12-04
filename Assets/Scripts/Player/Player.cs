using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField][Min(1)] private int _startCash;
    [Space]
    [Header("Player Components")]
    [SerializeField] private Mover _mover;
    [SerializeField] private CollisionHandler _collisionHandler;

    private int _cash;

    public event UnityAction<int> CashChanged;
    public event UnityAction GameLoss;

    public Mover Mover => _mover;

    public int Cash
    {
        get => _cash;
        private set
        {
            _cash = value;
            CashChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        _collisionHandler.Initialization(this);
    }

    public void ChangeCashTo(int value)
    {
        if (value > 0)
        {
            Cash = value;
        }
        else
        {
            Cash = 0;
            GameLoss?.Invoke();
        }
    }

    public void ResetPlayer()
    {
        Cash = _startCash;
    }
}
