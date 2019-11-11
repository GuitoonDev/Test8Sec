using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class DestroyTextOverTime : MonoBehaviour
{
    private void Start() {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        TextMeshPro textComponent = GetComponent<TextMeshPro>();
        textComponent.text = string.Format("LEVEL {0}", currentLevel);

        Destroy(gameObject, 2.5f);
    }
}
