using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _value;
    [SerializeField] private ParticleSystem _particleSystem;

    public float Value => _value;

    public void SetDisable()
    {
        _particleSystem.Play();
        _particleSystem.transform.parent = null;
        gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        _value = ((int)(_value * 100)) / 100f;
        if (_value <= 0)
            _value = 1;
    }
}
