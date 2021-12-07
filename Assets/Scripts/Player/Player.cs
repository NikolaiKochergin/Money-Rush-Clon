using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] [Min(0.01f)] private float _startCash;
    [Space]
    [Header("Player Components")]
    [SerializeField] private Mover _mover;
    [SerializeField] private AheadMovementRotation _aheadMovementRotation;
    [SerializeField] private MovementDamage _movementDamage;

    private float _cash;

    public event UnityAction<float> CashChanged;
    public event UnityAction GameFinished;
    public event UnityAction GameLoss;

    public Mover Mover => _mover;
    public AheadMovementRotation AheadMovementRotation => _aheadMovementRotation;
    public MovementDamage MovementDamage => _movementDamage;

    public float Cash
    {
        get => _cash;
        private set
        {
            _cash = value;
            CashChanged?.Invoke(value);
        }
    }

    private void Start()
    {
        SetStartState();
    }

    public void ChangeCash(Modifier.OperationType operationType, float value)
    {
        switch (operationType)
        {
            case Modifier.OperationType.Add:
                Cash += value;
                break;

            case Modifier.OperationType.Subtract:
                if (value >= _cash)
                {
                    SetGameLoss();
                    break;
                }
                Cash -= value;
                break;

            case Modifier.OperationType.Multiply:
                Cash *= value;
                break;

            case Modifier.OperationType.Divide:
                if (Cash / value <= 0)
                {
                    SetGameLoss();
                    break;
                }
                Cash /= value;
                break;
        }
    }

    public void SetStartState()
    {
        Cash = _startCash;
        transform.position = Vector3.zero;
        _mover.enabled = false;
        _aheadMovementRotation.enabled = false;
        _movementDamage.enabled = false;
    }

    public void OnGameFinished()
    {
        GameFinished?.Invoke();
    }

    private void SetGameLoss()
    {
        Cash = 0;
        GameLoss?.Invoke();
    }
}
