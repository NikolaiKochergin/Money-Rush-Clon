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

            switch (modifier.Type)
            {
                case Modifier.OperationType.Add:
                    _player.ChangeCashTo(_player.Cash + modifier.Value);
                    break;

                case Modifier.OperationType.Subtract:
                    _player.ChangeCashTo(_player.Cash - modifier.Value);
                    break;

                case Modifier.OperationType.Multiply:
                    _player.ChangeCashTo(_player.Cash * modifier.Value);
                    break;

                case Modifier.OperationType.Divide:
                    _player.ChangeCashTo(_player.Cash / modifier.Value);
                    break;
            }
        }
    }

    public void Initialization(Player player)
    {
        _player = player;
    }
}
