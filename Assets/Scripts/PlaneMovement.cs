using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Material planeMaterial;
    private Renderer planeRenderer;

    private void Start() {
        planeRenderer = transform.GetComponent<Renderer>();
        planeMaterial = planeRenderer.material;
    }

    private void Update() {
        Vector2 offset = planeMaterial.GetTextureOffset("_BaseMap");
        offset -= Vector2.up * moveSpeed * Time.deltaTime;
        planeMaterial.SetTextureOffset("_BaseMap", offset);
    }
}
