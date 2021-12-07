using UnityEngine;

[CreateAssetMenu(fileName = "NewModifierSettings", menuName = "Obstacle Resources/Modifier Settings")]
public class ModifierSettings : ScriptableObject
{
    [SerializeField] private Modifier.OperationType _type;
    [SerializeField] [Min(0.01f)] private float _value;

    public Modifier.OperationType Type => _type;
    public float Value => _value;

    private void OnValidate()
    {
        if (_type == Modifier.OperationType.RandomFromSettings)
            _type = Modifier.OperationType.Add;

        if (_type == Modifier.OperationType.Multiply || _type == Modifier.OperationType.Divide)
        {
            _value = Mathf.Round(_value);
            if (_value <= 0)
                _value = 1;
        }

        if (_type == Modifier.OperationType.Add || _type == Modifier.OperationType.Subtract)
        {
            _value = ((int)(_value * 100)) / 100f;
            if (_value <= 0)
                _value = 1;
        }
    }
}