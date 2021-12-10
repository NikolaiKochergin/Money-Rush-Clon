using UnityEngine;

public class ViewModel : MonoBehaviour
{
    [SerializeField] private AheadRotation _aheadRotation;
    [SerializeField] private PositionGiver _positionGiver;
    [SerializeField] private Scaler _scaler;
    [SerializeField] private TrailRenderer _trailRenderer;

    public AheadRotation AheadRotation => _aheadRotation;
    public PositionGiver PositionGiver => _positionGiver;
    public Scaler Scaler => _scaler;
    public TrailRenderer TrailRenderer => _trailRenderer;
}
