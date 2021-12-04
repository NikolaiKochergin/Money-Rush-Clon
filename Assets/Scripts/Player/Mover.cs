using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.forward * _speed;
    }
}
