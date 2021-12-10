using UnityEngine;

public class ViewModel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AheadMovementRotation _aheadMovementRotation;
    [SerializeField] private ViewPosition _viewPosition;
    [SerializeField] private TrailRenderer _trailRenderer;

    public Player Player => _player;
    public TrailRenderer TrailRenderer => _trailRenderer;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _aheadMovementRotation.enabled = true;
        _viewPosition.enabled = true;
    }

    private void OnDisable()
    {
        _aheadMovementRotation.enabled = false;
        _viewPosition.enabled = false;
    }
}
