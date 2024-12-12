using System.Collections;
using UnityEngine;
using TMPro;

public class LetterByLetterText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string fullText;
    public float delay = 0.1f;

    private void Start()
    {
        textComponent.text = "";
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textComponent.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }
}