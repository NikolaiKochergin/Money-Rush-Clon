using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] [Min(0)] private float _roadWidth;
    [SerializeField] [Range(0, 100)] private float _sensetivity;
    [SerializeField] [Min(0)] private float _turnSpeed;

    private PlayerInput _input;
    private float _deltaX;
    private Vector3 _targetDirection;
    private Vector3 _currentDirection;

    public float Speed => Vector3.Magnitude(_currentDirection) * _player.Speed;

    private void OnEnable()
    {
        _targetDirection = Vector3.forward;
        _currentDirection = Vector3.forward;
    }

    private void OnDisable()
    {
        _currentDirection = Vector3.forward;
        transform.rotation = Quaternion.LookRotation(_currentDirection);
    }

    private void Update()
    {
        _deltaX = _input.Player.MoveX.ReadValue<float>();
        if (_input.Player.Click.IsPressed())
            _targetDirection.x = Mathf.Clamp(_deltaX * _sensetivity, -1, 1);
        else
            _targetDirection.x = 0;

        if (transform.position.x >= _roadWidth / 2)
            _targetDirection.x = Mathf.Clamp(_targetDirection.x, -1, 0);

        if (transform.position.x <= -_roadWidth / 2)
            _targetDirection.x = Mathf.Clamp(_targetDirection.x, 0, 1);

        _currentDirection = Vector3.Lerp(_currentDirection, _targetDirection, _turnSpeed * Time.deltaTime);
        transform.position += _player.Speed * Time.deltaTime * _currentDirection;

        float positionX = Mathf.Clamp(transform.position.x, -_roadWidth / 2, _roadWidth / 2);
        
        transform.SetPositionAndRotation(new Vector3(positionX, transform.position.y, transform.position.z), Quaternion.LookRotation(_currentDirection));
    }

    public void Initialization(PlayerInput input)
    {
        _input = input ?? throw new ArgumentNullException(nameof(input));
    }
}
