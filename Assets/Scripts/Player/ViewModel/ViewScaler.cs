using UnityEngine;

public class ViewScaler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;

    private float _startPlayerCash;

    private void Awake()
    {
        _startPlayerCash = 200f;
    }

    private void OnEnable()
    {
        _player.CashChanged += OnCashChanged;
    }

    private void OnDisable()
    {
        _player.CashChanged -= OnCashChanged;
    }

    private void OnCashChanged(float value)
    {
        float localScale = Mathf.Clamp(value / _startPlayerCash, _minScale, _maxScale);

        transform.localScale = new Vector3(transform.localScale.x, localScale, localScale);
    }
}
