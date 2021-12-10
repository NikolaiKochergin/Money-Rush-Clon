using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    public event UnityAction<Modifier.OperationType, float> CashChanging;
    public event UnityAction GameFinished;

    private void OnTriggerEnter(Collider other)
    {
        var modifier = other.GetComponentInParent<Modifier>();
        var bonus = other.GetComponentInParent<Bonus>();
        var finishTrigger = other.GetComponent<FinishTrigger>();

        if (modifier)
        {
            modifier.gameObject.SetActive(false);
            CashChanging?.Invoke(modifier.Type, modifier.Value);
        }

        if (bonus)
        {
            bonus.SetDisable();
            CashChanging?.Invoke(Modifier.OperationType.Add, bonus.Value);
        }

        if (finishTrigger)
        {
            GameFinished?.Invoke();
        }
    }
}
