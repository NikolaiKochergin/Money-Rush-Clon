using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void OnEnable()
    {
        _collisionHandler.CashChanging += OnCashChanging;
    }

    private void OnDisable()
    {
        _collisionHandler.CashChanging -= OnCashChanging;
    }

    private void OnCashChanging(Modifier.OperationType type, float value)
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
