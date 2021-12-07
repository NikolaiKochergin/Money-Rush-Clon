using UnityEngine;

[RequireComponent(typeof(ViewModel))]
public class ViewPosition : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private CashView _cashView;
    [SerializeField] private float _cashViewOffsetY;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<ViewModel>().Player;
        OnValueChanged(_player.Cash.Value);
    }

    private void OnEnable()
    {
        _player.Cash.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.Cash.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        transform.localPosition = new Vector3(0, _collider.radius, 0) * transform.localScale.y;
        _cashView.transform.localPosition = new Vector3(0, _collider.radius * 2, 0) * transform.localScale.y + new Vector3(0, _cashViewOffsetY, 0);
    }
}
