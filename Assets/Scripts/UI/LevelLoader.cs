using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string _nextLevel;

    public void LoadNexLevel()
    {
        Scene loadedScene = SceneManager.GetSceneByName(_nextLevel);

        if (loadedScene.buildIndex != -1)
            SceneManager.LoadScene(loadedScene.buildIndex);
        else
            throw new System.Exception("Scene name incorrect");
    }
}