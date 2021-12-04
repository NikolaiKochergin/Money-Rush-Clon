using UnityEngine;

public class DisablerHandler : MonoBehaviour
{
    [SerializeField] private Modifier _PairModifier;

    private void Reset()
    {
        _PairModifier = GetComponent<Modifier>();
    }

    public void OnDisable()
    {
        _PairModifier.Collider.enabled = false;
    }
}