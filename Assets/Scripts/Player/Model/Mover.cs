using UnityEngine;

[RequireComponent(typeof(Player))]
public class Mover : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _roadWidth;
    [SerializeField] [Range(0, 0.1f)] private float _sensetivity;
    [SerializeField] [Min(0)] private float _rotationSpeed;

    private PlayerInput _input;
    private float _speed;
    private float _deltaX;

    private Vector3 _targetDirection;

    private Vector3 _currentDirection;

    private void OnEnable()
    {
        _speed = GetComponent<Player>().Speed;
        _targetDirection = Vector3.forward;
        _currentDirection = Vector3.forward;
    }

    private void OnDisable()
    {
        _targetDirection = Vector3.forward;
        _currentDirection = Vector3.forward;
        transform.rotation = Quaternion.LookRotation(_currentDirection);
    }

    private void Update()
    {
        _deltaX = _input.Player.MoveX.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        _targetDirection.z = 1;

        if (transform.position.x >= _roadWidth / 2)
            _targetDirection.x = Mathf.Clamp(_targetDirection.x, -1, _roadWidth / 2 - transform.position.x);

        if (transform.position.x <= -_roadWidth / 2)
            _targetDirection.x = Mathf.Clamp(_targetDirection.x, -_roadWidth / 2 - transform.position.x, 1);

        _currentDirection = Vector3.Lerp(_currentDirection, _targetDirection, _rotationSpeed * Time.fixedDeltaTime);
        transform.position += _currentDirection * _speed * Time.fixedDeltaTime;

        transform.rotation = Quaternion.LookRotation(_currentDirection);
    }

    public void Initialization(PlayerInput input)
    {
        _input = input;
        _input.Player.MoveX.performed += ctx => OnMoveX();
    }

    private void OnMoveX()
    {
        _targetDirection.x = Mathf.Clamp(_deltaX * _sensetivity, -1, 1);
    }
}
