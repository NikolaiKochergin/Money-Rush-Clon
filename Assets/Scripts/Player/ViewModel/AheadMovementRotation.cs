using UnityEngine;

public class AheadMovementRotation : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        float rotatioinX = _player.Mover.Speed / (2 * transform.localScale.x);

        transform.Rotate(Vector3.right, rotatioinX);
    }
}
