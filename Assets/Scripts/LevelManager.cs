using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        if (sceneName == "MainMenu")
        {
            MusicManager.instance.PlayMenuMusic();
        }
        else
        {
            int levelIndex = scene.buildIndex - 1; // MainMenu sahnesi 0'da ise, level sahneleri 1'den baþlar
            MusicManager.instance.PlayLevelMusic();
        }
    }
}
