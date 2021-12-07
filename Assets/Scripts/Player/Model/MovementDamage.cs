using UnityEngine;

[RequireComponent(typeof(Player))]
public class MovementDamage : MonoBehaviour
{
    [SerializeField] [Min(0.01f)] private float _damagePerDistance;
    [SerializeField] [Min(0.01f)] private float _distance;

    private Player _player;
    private float _currentDistance;
    private float _lastChackPosition;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

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
            _player.Cash.ChangeCash(Modifier.OperationType.Subtract, _damagePerDistance);
        }
    }
}
