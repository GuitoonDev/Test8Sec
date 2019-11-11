using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Camera mainCamera = null;

    [SerializeField] private float deltaPositionX = 1.9f;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(mainCamera.transform.position.z));

            newPosition = mainCamera.ScreenToWorldPoint(newPosition);
            newPosition.y = transform.position.y;
            newPosition.x = Mathf.Clamp(newPosition.x, -deltaPositionX, deltaPositionX);

            transform.position = newPosition;
        }
    }
}
