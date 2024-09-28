using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(int numberScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(numberScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}