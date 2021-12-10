using UnityEngine;

[RequireComponent(typeof(ViewModel))]
public class PositionGiver : MonoBehaviour
{
    [SerializeField]private Player _player;
    [SerializeField] private CashView _cashView;
    [SerializeField] private float _cashViewOffsetY;

    private void OnEnable()
    {
        _player.Cash.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.Cash.ValueChanged -= OnValueChanged;
    }

    public void Restart()
    {
        OnValueChanged(_player.StartCash);
    }

    private void OnValueChanged(float value)
    {
        transform.localPosition = new Vector3(0, transform.localScale.y / 2, 0);
        _cashView.transform.localPosition = new Vector3(0, transform.localScale.y + _cashViewOffsetY, 0);
    }
}
