using UnityEngine;

public class MovementDamage : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] [Min(0.01f)] private float _damagePerDistance;
    [SerializeField] [Min(0.01f)] private float _distance;

    private float _currentDistance;
    private float _lastChackPosition;

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
            _player.ChangeCash(Modifier.OperationType.Subtract, _damagePerDistance);
        }
    }
}
