using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(Renderer))]
public class Ball : MonoBehaviour
{
    public UnityAction OnBallDestroyed;
    public UnityAction OnGameOver;

    private new Renderer renderer;
    private MaterialPropertyBlock colorPropertyBlock;

    [SerializeField] private BallData ballData = null;
    [SerializeField] private TextMeshPro counterText = null;
    [SerializeField, Layer] private int paddleTriggerLayer = 0;
    [SerializeField, Layer] private int destroyBallsLayer = 0;

    [Header("Ball Settings")]
    [SerializeField] private Color color = Color.black;
    [SerializeField] private int minBounces = 1;
    [SerializeField] private int maxBounces = 9;

    public int BouncesBeforeDestroy { get; private set; }

    private void Awake() {
        renderer = GetComponent<Renderer>();
        colorPropertyBlock = new MaterialPropertyBlock();

        OnBallDestroyed += ballData.OnBallDestroyed;
        OnGameOver += ballData.OnGameOver;

        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        maxBounces = Mathf.Min(maxBounces - 8 + currentLevel, maxBounces);

        int pickedBouncesValue = Random.Range(minBounces, maxBounces + 1);
        if (pickedBouncesValue <= maxBounces / 4) {
            pickedBouncesValue += 2;
        }
        BouncesBeforeDestroy = pickedBouncesValue;
    }

    private void Start() {
        renderer.GetPropertyBlock(colorPropertyBlock);
        colorPropertyBlock.SetColor("_BaseColor", color);
        renderer.SetPropertyBlock(colorPropertyBlock);

        counterText.text = BouncesBeforeDestroy.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer.Equals(paddleTriggerLayer) && BouncesBeforeDestroy > 0) {
            BouncesBeforeDestroy--;
            counterText.text = BouncesBeforeDestroy.ToString();

            if (BouncesBeforeDestroy == 0) {
                counterText.color = Color.green;
                Destroy(gameObject, 1f);
                OnBallDestroyed();
            }
        }
        else if (other.gameObject.layer.Equals(destroyBallsLayer)) {
            Destroy(gameObject);
            OnGameOver();
        }
    }
}
