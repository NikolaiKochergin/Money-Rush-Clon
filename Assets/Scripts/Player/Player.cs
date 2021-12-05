using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] [Min(1)] private int _startCash;
    [Space]
    [Header("Player Components")]
    [SerializeField] private Mover _mover;

    private int _cash;
    private Vector3 _startPosition;

    public event UnityAction<int> CashChanged;
    public event UnityAction GameFinished;
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

    private void Start()
    {
        _startPosition = transform.position;
        _mover.enabled = false;
    }

    public void ChangeCash(Modifier.OperationType operationType, int value)
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

    public void ResetPlayer()
    {
        Cash = _startCash;
        transform.position = new Vector3(0, 0.5f, 0.5f);
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
