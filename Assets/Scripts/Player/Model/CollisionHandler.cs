using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event UnityAction GameFinished;

    private void OnTriggerEnter(Collider other)
    {
        var modifier = other.GetComponentInParent<Modifier>();
        var bonus = other.GetComponentInParent<Bonus>();
        var finishTrigger = other.GetComponent<FinishTrigger>();

        if (modifier)
        {
            modifier.gameObject.SetActive(false);

            _player.Cash.ChangeCash(modifier.Type, modifier.Value);
        }

        if (bonus)
        {
            bonus.SetDisable();

            _player.Cash.ChangeCash(Modifier.OperationType.Add, bonus.Value);
        }

        if (finishTrigger)
        {
            GameFinished?.Invoke();
        }
    }
}
