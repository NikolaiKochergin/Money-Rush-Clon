using UnityEngine;
using TMPro;

public class CashView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.CashChanged += OnCashChanged;
    }

    private void OnDisable()
    {
        _player.CashChanged -= OnCashChanged;
    }

    private void OnCashChanged(int value)
    {
        _text.text = value.ToString();
    }
}
