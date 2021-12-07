using UnityEngine;

public class ViewPosition : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private CashView _cashView;
    [SerializeField] private float _cashViewOffsetY;

    private void Update()
    {
        transform.localPosition = new Vector3(0, _collider.radius, 0) * transform.localScale.y;
        _cashView.transform.localPosition = new Vector3(0, _collider.radius * 2, 0) * transform.localScale.y + new Vector3(0, _cashViewOffsetY, 0);
    }
}
