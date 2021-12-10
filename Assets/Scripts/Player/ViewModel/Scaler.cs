using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] [Min(0)] private float _minScale;
    [SerializeField] [Min(0)] private float _maxScale;

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
        float localScale = Mathf.Clamp(value / _player.StartCash, _minScale, _maxScale);

        transform.localScale = new Vector3(transform.localScale.x, localScale, localScale);
    }
}
