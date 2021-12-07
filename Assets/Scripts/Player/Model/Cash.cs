using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class Cash : MonoBehaviour
{
    private Player _player;
    private float _value;

    public event UnityAction<float> ValueChanged;
    public event UnityAction GameLoss;

    public float Value
    {
        get => _value;
        private set
        {
            _value = value;
            ValueChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    public void Restart()
    {
        Value = _player.StartCash;
    }

    public void ChangeCash(Modifier.OperationType operationType, float value)
    {
        switch (operationType)
        {
            case Modifier.OperationType.Add:
                Value += value;
                break;

            case Modifier.OperationType.Subtract:
                if (value >= _value)
                {
                    SetGameLoss();
                    break;
                }
                Value -= value;
                break;

            case Modifier.OperationType.Multiply:
                Value *= value;
                break;

            case Modifier.OperationType.Divide:
                if (_value / value <= 0)
                {
                    SetGameLoss();
                    break;
                }
                Value /= value;
                break;
        }
    }

    private void SetGameLoss()
    {
        Value = 0;
        GameLoss?.Invoke();
    }
}
