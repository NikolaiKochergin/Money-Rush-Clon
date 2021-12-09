using UnityEngine;
using TMPro;
using System.Globalization;
using System.Threading;

public class CashView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        OnValueChanged(_player.Cash.Value);
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
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
        _text.text = string.Format("{0:C2}", value);
    }
}
