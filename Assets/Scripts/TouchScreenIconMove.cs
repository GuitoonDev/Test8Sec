using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class TouchScreenIconMove : MonoBehaviour
{


    private void Start() {
        RectTransform rectTransform = GetComponent<RectTransform>();

        rectTransform.DOScale(Vector2.one * 1.2f, 1f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
        rectTransform.DOAnchorPosX(255, 2f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            Destroy(gameObject);
        }
    }
}
