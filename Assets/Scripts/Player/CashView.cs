using UnityEngine;
using TMPro;
using System.Globalization;
using System.Threading;

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

    private void OnCashChanged(float value)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        _text.text = string.Format("{0:C2}", value);
    }
}
