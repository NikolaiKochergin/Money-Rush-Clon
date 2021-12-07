using UnityEngine;

public class ViewScaler : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _minScale;
    [SerializeField] [Min(0)] private float _maxScale;

    private ViewModel _viewModel;
    private float _startPlayerCash;

    private void Awake()
    {
        _viewModel = GetComponent<ViewModel>();
        _startPlayerCash = _viewModel.Player.StartCash;
        OnValueChanged(_viewModel.Player.Cash.Value);
    }

    private void OnEnable()
    {
        _viewModel.Player.Cash.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _viewModel.Player.Cash.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        float localScale = Mathf.Clamp(value / _startPlayerCash, _minScale, _maxScale);

        transform.localScale = new Vector3(transform.localScale.x, localScale, localScale);
    }
}
