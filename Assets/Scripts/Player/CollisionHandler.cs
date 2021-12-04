using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Player _player;


    private void OnTriggerEnter(Collider other)
    {
        var modifier = other.GetComponentInParent<Modifier>();

        if (modifier)
        {
            modifier.gameObject.SetActive(false);
        }
    }

    public void Initialization(Player player)
    {
        _player = player;
    }
}
