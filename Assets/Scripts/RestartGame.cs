using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene("TestLevel");
        Time.timeScale = 1;
    }
}
