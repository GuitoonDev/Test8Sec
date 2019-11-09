using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private BallData ballData = null;

    [SerializeField] private Image fadeImage = null;
    [SerializeField] private TextMeshProUGUI firstLineText = null;
    [SerializeField] private TextMeshProUGUI secondLineText = null;
    [SerializeField] private RectTransform firstLineFinalPosition = null;
    [SerializeField] private RectTransform secondLineFinalPosition = null;

    private void Start() {
        ballData.OnEndLevel += ShowEndGameMessage;

        fadeImage.DOFade(0f, 1.3f);
    }

    private void ShowEndGameMessage(bool _isWon) {
        if (_isWon) {
            Debug.Log("Level win !");
        }
        else {
            Debug.Log("Game Over...");
        }

        fadeImage.DOFade(1f, 1.5f)
            .OnComplete(() => {
                StartCoroutine(WaitForNewGame());
            });

        if (_isWon) {
            firstLineText.text = "LEVEL";
            secondLineText.text = "COMPLETE !";
        }
        else {
            firstLineText.text = "TRY";
            secondLineText.text = "AGAIN <3";
        }

        firstLineText.GetComponent<RectTransform>().DOAnchorPos(firstLineFinalPosition.anchoredPosition, 0.75f).SetEase(Ease.OutQuad)
            .OnComplete(() => {
                secondLineText.GetComponent<RectTransform>().DOAnchorPos(secondLineFinalPosition.anchoredPosition, 0.75f).SetEase(Ease.OutQuad);
            });
    }

    private IEnumerator WaitForNewGame() {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
