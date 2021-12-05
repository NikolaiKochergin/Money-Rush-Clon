using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();

        if (player)
        {
            player.OnGameFinished();
        }
    }
}
