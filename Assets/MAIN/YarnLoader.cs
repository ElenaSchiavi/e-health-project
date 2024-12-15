using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using Yarn.Unity;

public class YarnCSLoader : MonoBehaviour //YARN CUSTOM SCRIPT LOADER
{

    public static YarnCSLoader Instance; // Singleton instance
    private static RectTransform uiObject = null;
    private static Graphic uiGraphic = null;
    private static Graphic glowGraphic = null;
    
    private float speed = 700f; 
    private static Vector2 offScreenLeft  = new Vector2(-750f, -125f);
    private static Vector2 offScreenRight = new Vector2(285f, -125f);
    private static Vector2 scenePosition  = new Vector2(0f, 0f); //placeholder value

    private static bool isMovingToScene = false;
    private static bool isExitingSceneLeft  = false;
    private static bool isExitingSceneRight  = false;

    private static bool isFadingIn  = false;
    private static bool isFadingOut = false;

    private static bool isGlowing = false;


    static int sigarette_fumate = 0;
    static int mood = 0;
    static int issergio = 0;

    public static float fadeDuration = 1.0f; // Duration of the fade in seconds

    private static float targetAlpha;
    private static float fadeSpeed;

    public float glowSpeed = 1.0f; // Speed of the glow effect
    public float minAlpha = 0.0f; // Minimum alpha value for glow effect
    public float maxAlpha = 1.0f; // Maximum alpha value for glow effect


    // note: all Yarn Functions must be static
    [YarnFunction("getSigarette")]
    public static int getSigarette()
    {
        Debug.Log($"Yarn read sigarette_fumate from YarnCSLoader: {sigarette_fumate}");
        return sigarette_fumate;
    }

    // Yarb Commands can be static or non-static
    [YarnCommand("setSigarette")]
    public static void setSigarette(int newNumber)
    {
        Debug.Log($"Yarn set sigarette_fumate to YarnCSLoader: {newNumber}");
        sigarette_fumate = newNumber;
    }

    [YarnCommand("addSigaretta")]
    public static void addSigaretta()
    {
        sigarette_fumate++;
        Debug.Log($"Yarn add one to sigarette_fumate in YarnCSLoader: {sigarette_fumate}");
    }

    [YarnFunction("getMood")]
    public static int getMood()
    {
        Debug.Log($"Yarn read mood from YarnCSLoader: {mood}");
        return mood;
    }

    [YarnCommand("setMood")]
    public static void setMood(int newNumber)
    {
        Debug.Log($"Yarn set mood to YarnCSLoader: {newNumber}");
        mood = newNumber;
    }

    [YarnCommand("addMood")]
    public static void addMood()
    {
        mood++;
        Debug.Log($"Yarn add one to mood in YarnCSLoader: {mood}");
    }

    [YarnCommand("minusMood")]
    public static void minusMood()
    {
        mood--;
        Debug.Log($"Yarn take one to mood in YarnCSLoader: {mood}");
    }

    [YarnFunction("getSergio")]
    public static int getSergio()
    {
        Debug.Log($"Yarn read mood from YarnCSLoader: {issergio}");
        return issergio;
    }

    [YarnCommand("setSergio")]
    public static void setSergio(int newNumber)
    {
        Debug.Log($"Yarn set mood to YarnCSLoader: {newNumber}");
        issergio = newNumber;
    }

    [YarnCommand("loadScene")]
    public static void LoadScene(string sceneName)
    {
        // Debug: Verify the command is being called
        Debug.Log($"Loading scene: {sceneName}");

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Add it to the Build Settings.");
        }
    }

    [YarnCommand("hideCharacter")]
    public static void hideElement(string elementName)
    {
        GameObject elementToHide = GameObject.Find(elementName);
        if (elementToHide != null)
        {
            elementToHide.SetActive(false);
            Debug.Log($"{elementToHide.name} has been hidden.");
        }
        else
        {
            Debug.LogError($"UI Element named '{elementName}' could not be found.");
        }
    }

    [YarnCommand("showCharacter")]
    public static void showElement(string elementName)
    {
        GameObject elementToShow = FindInactiveObjectByNameInScene(elementName);
        if (elementToShow != null)
        {
            elementToShow.SetActive(true);
            Debug.Log($"{elementToShow.name} has been hidden.");
        }
        else
        {
            Debug.LogError($"UI Element named '{elementName}' could not be found.");
        }
    }

    public static GameObject FindInactiveObjectByName(string name, Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child.gameObject;

            GameObject result = FindInactiveObjectByName(name, child);
            if (result != null)
                return result;
        }

        return null;
    }

    public static GameObject FindInactiveObjectByNameInScene(string name)
    {
        // GetRootGameObjects() returns GameObject[], not Transform[]
        foreach (GameObject root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            GameObject result = FindInactiveObjectByName(name, root.transform); // Use root.transform
            if (result != null)
                return result;
        }

        return null;
    }
    
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the object alive across scene loads
        }
        else
        {
            Destroy(gameObject); // If another instance is found, destroy it
            return; // Prevent further execution if this instance is destroyed
        }
    }
    
    void Update()
    {
        if (isMovingToScene)
            MoveToPosition(scenePosition, ref isMovingToScene);
        
        if (isExitingSceneLeft) 
            MoveToPosition(offScreenLeft, ref isExitingSceneLeft);   

        if (isExitingSceneRight) 
            MoveToPosition(offScreenRight, ref isExitingSceneRight);   

        if (isFadingIn|| isFadingOut) {
           if (uiGraphic != null && !Mathf.Approximately(uiGraphic.color.a, targetAlpha))
           {
                // Gradually change the alpha value
                Color currentColor = uiGraphic.color;
                currentColor.a = Mathf.MoveTowards(currentColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
                uiGraphic.color = currentColor;
              }
            else {
                isFadingIn = false;
                isFadingOut = false;
            }
           }
        if (isGlowing)
        {
            // Calculate alpha based on a sine wave
            float alpha = (Mathf.Sin(Time.time * glowSpeed) + 1) / 2; // Normalize to 0-1
            alpha = Mathf.Lerp(minAlpha, maxAlpha, alpha); // Scale to minAlpha and maxAlpha

            // Apply the alpha to the UI element
            Color currentColor = glowGraphic.color;
            currentColor.a = alpha;
            glowGraphic.color = currentColor;
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

    [YarnCommand("exitScene")]
    public static void ExitScene(string elementName, string dir = "left")
    {

        GameObject elementToMove = GameObject.Find(elementName);
        if (elementToMove != null)
        {
            uiObject=elementToMove.GetComponent<RectTransform>();
            Debug.Log($"RectTransform Assigned");
            
            if (dir=="left") isExitingSceneLeft = true;
            else if (dir=="right") isExitingSceneRight = true;
            else {
                Debug.Log($"Direzione non riconosciuta, defaulting to Left");
                isExitingSceneLeft = true;
            }
            Debug.Log($"\"Is exiting scene\" triggered");

        }
        else
        {
            Debug.LogError($"Failed finding UI element");
        }
    }

    [YarnCommand("enterScene")]
    public static void EnterScene(string elementName, string dir = "left")
    {

        GameObject elementToMove = GameObject.Find(elementName);
        if (elementToMove != null)
        {
            uiObject=elementToMove.GetComponent<RectTransform>();
            Debug.Log($"RectTransform Assigned");
            Debug.Log($"Setting destination position:");
            scenePosition = uiObject.anchoredPosition;
            Debug.Log($"UI Position: {scenePosition}");
            if(dir=="left") uiObject.anchoredPosition = offScreenLeft;
            else if (dir=="right") uiObject.anchoredPosition = offScreenRight;
            else {
                uiObject.anchoredPosition = offScreenRight;
                Debug.LogError($"Direction invalid, falling back to default left");
                }
            
            isMovingToScene = true;
            Debug.Log($"\"Is moving to scene\" triggered");

        }
        else
        {
            Debug.LogError($"Failed finding UI element");
        }
    }
    
    [YarnCommand("fadeIn")]
    public static void FadeIn(string elementName)
    {
        GameObject elementToFade = GameObject.Find(elementName);
        if (elementToFade != null)
        {
            uiGraphic=elementToFade.GetComponent<Graphic>();
            Debug.Log($"UiGraphic Assigned");

            isFadingIn = true;
            StartFade(1f);

            Debug.Log($"\"Is Fading In\" triggered");

        }
        else
        {
            Debug.LogError($"Failed finding UI element");
        }
    }
    
    [YarnCommand("fadeOut")]
    public static void FadeOut(string elementName)
    {

        GameObject elementToFade = GameObject.Find(elementName);
        if (elementToFade != null)
        {
            uiGraphic=elementToFade.GetComponent<Graphic>();
            Debug.Log($"UiGraphic Assigned");

            isFadingOut = true;
            StartFade(0f);
            Debug.Log($"\"Is Fading Out\" triggered");

        }
        else
        {
            Debug.LogError($"Failed finding UI element");
        }
    }
    
    public static void StartFade(float newAlpha)
    {
        if (uiGraphic != null)
        {
            targetAlpha = Mathf.Clamp01(newAlpha); // Clamp between 0 and 1
            fadeSpeed = Mathf.Abs(uiGraphic.color.a - targetAlpha) / fadeDuration;
        }
    }
    
    [YarnCommand("startGlow")]
    public static void StartGlow(string elementName)
    {
        GameObject elementToGlow = GameObject.Find(elementName);
        if (elementToGlow != null)
        {
            glowGraphic=elementToGlow.GetComponent<Graphic>();
            Debug.Log($"glowGraphic Assigned");

            isGlowing = true;
            Debug.Log($"\"Is Glowing\" triggered");

        }
        else
        {
            Debug.LogError($"Failed finding UI element");
        }
    }
    
    [YarnCommand("stopGlow")]
    public static void StopGlow(string elementName)
    {
        isGlowing = false;
        FadeIn(elementName);
    }
}