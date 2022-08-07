using UnityEngine;

public class ColorGradient : MonoBehaviour
{
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private float _smoothness;


    private void Start()
    {
        _smoothness = 5f / GetComponent<Barrier>().Health;
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = Color.Lerp (_color1, _color2, _smoothness);
    }



}
