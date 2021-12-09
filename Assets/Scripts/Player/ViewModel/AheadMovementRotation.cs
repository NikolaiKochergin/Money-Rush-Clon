using UnityEngine;

[RequireComponent(typeof(ViewModel))]
public class AheadMovementRotation : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<ViewModel>().Player;
    }

    private void Update()
    {
        float rotatioinX = _player.Mover.Speed / (Mathf.PI * transform.localScale.y);

        transform.Rotate(Vector3.right, rotatioinX);
    }
}
