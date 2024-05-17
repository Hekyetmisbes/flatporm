using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager instance;

    public List<string> scenes; // List of scene names in the order they should be played
    private int currentSceneIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextScene()
    {
        if (currentSceneIndex < scenes.Count - 1)
        {
            currentSceneIndex++;
            SceneManager.LoadScene(scenes[currentSceneIndex]);
        }
        else
        {
            Debug.Log("All scenes completed");
        }
    }

    public string GetNextSceneName()
    {
        if (currentSceneIndex < scenes.Count - 1)
        {
            return scenes[currentSceneIndex + 1];
        }
        else
        {
            return null; // No more scenes to load
        }
    }
}
