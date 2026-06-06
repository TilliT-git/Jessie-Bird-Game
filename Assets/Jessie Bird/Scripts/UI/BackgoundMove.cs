using UnityEngine;

public class BackgoundMove : MonoBehaviour
{
    [Header("Background Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private MeshRenderer _meshRenderer;

    [Header("Background Offset")]
    private float offset;

    private void Update()
    {
        offset += Time.deltaTime * _speed;

        float x = Mathf.Repeat(offset, 1);

        _meshRenderer.sharedMaterial.mainTextureOffset = new Vector2(x, 0);
    }
}