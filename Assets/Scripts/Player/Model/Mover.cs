using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] [Min(0)] private float _roadWidth;
    [SerializeField] [Range(0, 100)] private float _sensetivity;
    [SerializeField] [Min(0)] private float _turnSpeed;

    private PlayerInput _input;
    private float _speed;
    private float _deltaX;
    private bool _isPressed;

    private Vector3 _targetDirection;
    private Vector3 _currentDirection;

    public float Speed => Vector3.Magnitude(_currentDirection) * _speed;

    private void OnEnable()
    {
        _speed = _player.Speed;
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
        _isPressed = _input.Player.Click.IsPressed();
    }

    private void FixedUpdate()
    {
        _targetDirection.z = 1;

        if (transform.position.x + _currentDirection.x * _speed >= _roadWidth / 2)
            _targetDirection.x = Mathf.Clamp(_targetDirection.x, -1, 0);

        if (transform.position.x + _currentDirection.x * _speed <= -_roadWidth / 2)
            _targetDirection.x = Mathf.Clamp(_targetDirection.x, 0, 1);

        _currentDirection = Vector3.Lerp(_currentDirection, _targetDirection, _turnSpeed * Time.fixedDeltaTime);
        transform.position += _currentDirection * _speed * Time.fixedDeltaTime;

        transform.rotation = Quaternion.LookRotation(_currentDirection);
    }

    public void Initialization(PlayerInput input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        _input = input;
        _input.Player.MoveX.performed += ctx => OnMoveX();
    }

    private void OnMoveX()
    {
        if (_isPressed)
            _targetDirection.x = Mathf.Clamp(_deltaX * _sensetivity, -1, 1);
        else
            _targetDirection.x = 0;
    }
}
