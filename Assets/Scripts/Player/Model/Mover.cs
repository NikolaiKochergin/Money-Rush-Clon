using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class Mover : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _roadWidth;
    [SerializeField] [Range(0, 0.1f)] private float _sensetivity;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private float _speed;
    private float _screenTouchDeltaX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _speed = GetComponent<Player>().Speed;
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

    public void Initialization(PlayerInput input)
    {
        _input = input;
        _input.Player.MoveX.performed += ctx => OnMoveX();
    }

    private void OnMoveX()
    {
        float targetPositionX = Mathf.Clamp(transform.position.x + (_screenTouchDeltaX * _sensetivity), -_roadWidth / 2, _roadWidth / 2);
        float positionX = Mathf.MoveTowards(transform.position.x, targetPositionX, _speed * Time.deltaTime);

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
    }
}
