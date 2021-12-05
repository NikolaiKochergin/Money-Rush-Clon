using UnityEngine;

[RequireComponent(typeof(Player))]
public class CollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var modifier = other.GetComponentInParent<Modifier>();
        var bonus = other.GetComponentInParent<Bonus>();

        if (modifier)
        {
            modifier.gameObject.SetActive(false);

            _player.ChangeCash(modifier.Type, modifier.Value);
        }

        if (bonus)
        {
            bonus.gameObject.SetActive(false);

            _player.ChangeCash(Modifier.OperationType.Add, bonus.Value);
        }
    }
}
