using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private ParticleSystem _particleSystem;

    public int Value => _value;

    public void SetDisable()
    {
        _particleSystem.Play();
        _particleSystem.transform.parent = null;
        gameObject.SetActive(false);
    }
}
