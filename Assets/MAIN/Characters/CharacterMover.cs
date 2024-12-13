using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public RectTransform uiObject;
    public float speed = 700f; 
    public Vector2 offScreenLeft = new Vector2(-733f, -125f);
    public Vector2 scenePosition = new Vector2(-450f, -125f);

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
            MoveToPosition(scenePosition, ref isMovingToScene);
        }

        if (isExitingScene)
        {
            MoveToPosition(offScreenLeft, ref isExitingScene);
        }
    }

    private void MoveToPosition(Vector2 targetPosition, ref bool toggleFlag)
    {
        uiObject.anchoredPosition = Vector2.MoveTowards(
            uiObject.anchoredPosition,
            targetPosition,
            speed * Time.deltaTime
        );

        if (uiObject.anchoredPosition == targetPosition)
        {
            toggleFlag = false;
        }
    }

    public void ExitScene()
    {
        isExitingScene = true;
    }
}