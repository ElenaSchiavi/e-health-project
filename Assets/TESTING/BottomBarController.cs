using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }


   public void PlayScene(StoryScene scene)
   {
       if (scene == null)
       {
           Debug.LogError("No StoryScene assigned to BottomBarController.");
           return;
       }

       if (scene.sentences == null || scene.sentences.Count == 0)
       {
           Debug.LogError("The StoryScene has no sentences!");
           return;
       }

       currentScene = scene;
       sentenceIndex = -1;
       PlayNextSentence();
   }


    public void PlayNextSentence()
    {
        if (barText == null || personNameText == null)
        {
            Debug.LogError("barText or personNameText is not assigned in the Inspector!");
            return;
        }
        if (barText == null || personNameText == null)
        {
            Debug.LogError("barText or personNameText is not assigned in the Inspector!");
            return;
        }
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Debug.LogWarning("Text is empty or null.");
            yield break;
        }

        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        Debug.Log($"Typing text: {text}");

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);

            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                Debug.Log("Text typing completed.");
                break;
            }
        }
    }

}
