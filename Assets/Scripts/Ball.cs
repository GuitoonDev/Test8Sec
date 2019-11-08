using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private new Renderer renderer;
    private MaterialPropertyBlock colorPropertyBlock;

    [SerializeField] private TextMeshPro counterText = null;
    [SerializeField, Layer] private int paddleCollisionLayer = 0;

    [Header("Ball Settings")]
    [SerializeField] private int bouncesBeforeDestroy = 1;
    [SerializeField] private Color color = Color.black;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        colorPropertyBlock = new MaterialPropertyBlock();
    }

    private void Start() {
        renderer.GetPropertyBlock(colorPropertyBlock);
        colorPropertyBlock.SetColor("_BaseColor", color);
        renderer.SetPropertyBlock(colorPropertyBlock);

        counterText.text = bouncesBeforeDestroy.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer.Equals(paddleCollisionLayer) && bouncesBeforeDestroy > 0) {
            bouncesBeforeDestroy--;
            counterText.text = bouncesBeforeDestroy.ToString();

            if (bouncesBeforeDestroy == 0) {
                Destroy(gameObject, 1f);
            }
        }
    }
}
