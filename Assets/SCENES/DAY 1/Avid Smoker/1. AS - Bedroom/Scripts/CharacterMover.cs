using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public RectTransform uiObject;
    public float speed = 700f; 
    public Vector2 offScreenLeft = new Vector2(-733f, -125f);
    public Vector2 scenePosition = new Vector2(-450f, -125f);
    public Vector2 offScreenRight = new Vector2(733f, -125f);

    private bool isMovingToScene = true;
    private bool isExitingScene = false;

    void Start()
    {
        uiObject.anchoredPosition = offScreenLeft;
    }

    void Update()
    {
        if (isMovingToScene)
        {
            uiObject.anchoredPosition = Vector2.MoveTowards(
                uiObject.anchoredPosition,
                scenePosition,
                speed * Time.deltaTime
            );

            if (uiObject.anchoredPosition == scenePosition)
            {
                isMovingToScene = false;
            }
        }

        if (isExitingScene)
        {
            uiObject.anchoredPosition = Vector2.MoveTowards(
                uiObject.anchoredPosition,
                offScreenRight,
                speed * Time.deltaTime
            );

            if (uiObject.anchoredPosition == offScreenRight)
            {
                isExitingScene = false;
            }
        }
    }

    public void ExitScene()
    {
        isExitingScene = true;
    }
}