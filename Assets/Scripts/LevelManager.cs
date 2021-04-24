using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int activeSceneIndex;

    private void Awake() => instance = this;

    private void Start()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartLevel()
    {
        Debug.Log("Reseting level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Debug.Log("Loading next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
