using System.Collections;
using UnityEngine;
using TMPro;

public class LetterByLetterText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;  // Il componente TextMeshPro
    public string fullText;                // Il testo completo da mostrare
    public float delay = 0.1f;             // Ritardo tra una lettera e l'altra

    private void Start()
    {
        textComponent.text = "";  // Inizializza con testo vuoto
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