using UnityEngine;

public class TextureOffsetter : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Transform _transform;


    private void OnEnable()
    {
        _material.mainTextureOffset = Vector2.zero;
    }

    private void OnDisable()
    {
        _material.mainTextureOffset = Vector2.zero;
    }

    private void Update()
    {
        _material.mainTextureOffset = new Vector2(-_transform.position.z/2, 0);
    }
}
