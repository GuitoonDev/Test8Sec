using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BounceSpeed : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    [SerializeField, Layer] private int paddleCollisionLayer = 0;
    [SerializeField] private float horizontalSpeed = 1f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer.Equals(paddleCollisionLayer)) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * horizontalSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
        }
    }
}
