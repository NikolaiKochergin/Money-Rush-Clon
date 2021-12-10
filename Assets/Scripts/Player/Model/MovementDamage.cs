using UnityEngine;
using UnityEngine.Events;

public class MovementDamage : MonoBehaviour
{
    [SerializeField] [Min(0.01f)] private float _damagePerDistance;
    [SerializeField] [Min(0.01f)] private float _distance;

    private float _currentDistance;
    private float _lastChackPosition;

    public event UnityAction<Modifier.OperationType, float> CashChanging;

    private void OnEnable()
    {
        _lastChackPosition = transform.position.z;
    }

    private void Update()
    {
        _currentDistance = transform.position.z - _lastChackPosition;

        if (_currentDistance >= _distance)
        {
            _lastChackPosition = transform.position.z;
            CashChanging?.Invoke(Modifier.OperationType.Subtract, _damagePerDistance);
        }
    }
}
