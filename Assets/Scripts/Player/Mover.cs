using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] [Min(0)] private float _speed;
    [SerializeField] [Min(0)] private float _roadWidth;
    [SerializeField] [Range(0, 0.01f)] private float _sensetivity;

    private PlayerInput _input;
    private float _screenTouchDeltaX;

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Update()
    {
        _screenTouchDeltaX = _input.Player.MoveX.ReadValue<float>();
    }

    public void OnMoveX()
    {
        float targetPositionX = Mathf.Clamp(transform.position.x + (_screenTouchDeltaX * _sensetivity), -_roadWidth / 2, _roadWidth / 2);

        transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);
    }

    public void Initialization(PlayerInput input)
    {
        _input = input;
        _input.Player.MoveX.performed += ctx => OnMoveX();
    }
}
