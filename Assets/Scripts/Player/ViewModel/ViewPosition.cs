using UnityEngine;

public class ViewPosition : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private CashView _cashView;
    [SerializeField] private float _cashViewOffsetY;

    private void OnEnable()
    {
        _player.CashChanged += OnCashCanged;
    }

    private void OnDisable()
    {
        _player.CashChanged -= OnCashCanged;
    }

    private void OnCashCanged(float value)
    {
        transform.localPosition = new Vector3(0, _collider.radius, 0) * transform.localScale.y;
        _cashView.transform.localPosition = new Vector3(0, _collider.radius * 2, 0) * transform.localScale.y + new Vector3(0, _cashViewOffsetY, 0);
    }
}
