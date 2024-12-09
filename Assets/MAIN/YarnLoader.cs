using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnCSLoader : MonoBehaviour   //YARN CUSTOM SCRIPT LOADER
{

  static int sigarette_fumate = 0;
  static int mood = 0;

  // note: all Yarn Functions must be static
  [YarnFunction("getSigarette")]
  public static int getSigarette() { 
      Debug.Log($"Yarn read sigarette_fumate from YarnCSLoader: {sigarette_fumate}");
      return sigarette_fumate; 
  }

  // Yarb Commands can be static or non-static
  [YarnCommand("setSigarette")]
  public static void setSigarette(int newNumber) { 
    Debug.Log($"Yarn set sigarette_fumate to YarnCSLoader: {newNumber}");
    sigarette_fumate = newNumber;
  }

  [YarnCommand("addSigaretta")]
  public static void addSigaretta() { 
    sigarette_fumate++;
    Debug.Log($"Yarn add one to sigarette_fumate in YarnCSLoader: {sigarette_fumate}");
  }

 [YarnFunction("getMood")]
  public static int getMood() { 
      Debug.Log($"Yarn read mood from YarnCSLoader: {mood}");
      return mood; 
  }

  [YarnCommand("setMood")]
  public static void setMood(int newNumber) { 
    Debug.Log($"Yarn set mood to YarnCSLoader: {newNumber}");
    mood = newNumber;
  }

  [YarnCommand("addMood")]
  public static void addMood() { 
    mood++;
    Debug.Log($"Yarn add one to mood in YarnCSLoader: {mood}");
  }

  [YarnCommand("minusMood")]
  public static void minusMood() { 
    mood--;
    Debug.Log($"Yarn take one to mood in YarnCSLoader: {mood}");
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
        GameObject elementToShow =FindInactiveObjectByNameInScene(elementName);
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


    public static YarnCSLoader Instance; // Singleton instance
  
    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This line keeps the object alive across scene loads
        }
        else
        {
            Destroy(gameObject); // If another instance is found, destroy it
        }
    }

}
