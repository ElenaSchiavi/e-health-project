using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public TextAsset inkfile;
    public TextMeshProUGUI textBox;

    private Story story;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        story = new Story(inkfile.text);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if(story.canContinue)
        {
            textBox.gameObject.SetActive(true);
            textBox.text = story.Continue();
        }
        else
        {
            FinishDialogue();
        }
    }

    private void FinishDialogue()
    {
        textBox.gameObject.SetActive(false);
    }
}
