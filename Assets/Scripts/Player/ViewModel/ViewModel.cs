using UnityEngine;

public class ViewModel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AheadMovementRotation _aheadMovementRotation;

    public Player Player => _player;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _aheadMovementRotation.enabled = true;
    }

    private void OnDisable()
    {
        _aheadMovementRotation.enabled = false;
    }
}
