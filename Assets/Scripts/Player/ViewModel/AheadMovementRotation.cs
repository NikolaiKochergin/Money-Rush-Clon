using UnityEngine;

[RequireComponent(typeof(ViewModel))]
public class AheadMovementRotation : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<ViewModel>().Player;
    }

    private void FixedUpdate()
    {
        float rotatioinX = 2 * Mathf.Rad2Deg * _player.Mover.Speed / transform.localScale.y;

        transform.Rotate(Vector3.right, transform.rotation.x + rotatioinX * Time.fixedDeltaTime);
    }
}
