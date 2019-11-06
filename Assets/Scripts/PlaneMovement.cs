using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Renderer planeRenderer;

    private void Start() {
        planeRenderer = transform.GetComponent<Renderer>();
    }

    private void Update() {
        Vector2 offset = planeRenderer.material.GetTextureOffset("_BaseMap");
        offset -= Vector2.up * moveSpeed * Time.deltaTime;
        planeRenderer.material.SetTextureOffset("_BaseMap", offset);
    }
}
