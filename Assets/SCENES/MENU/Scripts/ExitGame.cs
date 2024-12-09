using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
            // Se sei in modalità editor, fermare il Play Mode
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Se sei in modalità di build, chiudere l'applicazione
            Application.Quit();
        #endif
    }
}