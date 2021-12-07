using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float _startCash;
    [SerializeField] [Min(0)] private float _speed;

    [Header("Player Components")]
    [SerializeField] private Cash _cash;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Mover _mover;
    [SerializeField] private MovementDamage _movementDamage;
    [SerializeField] private ViewModel _viewModel;

    public float StartCash => _startCash;
    public float Speed => _speed;
    public Cash Cash => _cash;
    public CollisionHandler CollisionHandler => _collisionHandler;
    public Mover Mover => _mover;
    public MovementDamage MovementDamage => _movementDamage;
    public ViewModel ViewModel => _viewModel;

    private void OnValidate()
    {
        _startCash = ((int)(_startCash * 100)) / 100f;
        if (_startCash <= 0)
            _startCash = 1;
    }
}
